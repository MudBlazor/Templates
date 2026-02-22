using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[GitHubActions(
    "continuous",
    GitHubActionsImage.UbuntuLatest,
    FetchDepth = 0,
    On = [GitHubActionsTrigger.Push],
    PublishArtifacts = true,
    InvokedTargets = [nameof(Compile), nameof(Pack)])]
[GitHubActions(
    "release",
    GitHubActionsImage.UbuntuLatest,
    FetchDepth = 0,
    OnPushTags = [@"\d+\.\d+\.\d+"],
    PublishArtifacts = true,
    InvokedTargets = [nameof(Push), nameof(PushGithubNuget)],
    ImportSecrets = [nameof(NugetKey), nameof(GithubToken)])]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = Configuration.Release;

    [Parameter] readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json"; //default
    [Parameter][Secret] readonly string NugetKey;
    [Parameter][Secret] readonly string GithubToken;

    bool RunFormatAnalyzers => false;

    bool IsTag => GitHubActions.Instance?.Ref?.StartsWith("refs/tags/") ?? false;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    AbsolutePath PackagesDirectory => ArtifactsDirectory / "packages";

    Target Clean => _ => _
           .Before(Restore)
           .Executes(() =>
           {
               SourceDirectory.GlobDirectories("*/bin", "*/obj").DeleteDirectories();
               TestsDirectory.GlobDirectories("*/bin", "*/obj").DeleteDirectories();
               ArtifactsDirectory.CreateOrCleanDirectory();
           });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target VerifyFormat => _ => _
        .After(Restore)
        .Description("Verify code formatting for the solution.")
        .Executes(() =>
        {
            DotNet($"format whitespace {Solution.Path} --verify-no-changes ");

            DotNet($"format style {Solution.Path} --verify-no-changes ");

            if (RunFormatAnalyzers)
            {
                DotNet($"format analyzers {Solution.Path} --verify-no-changes ");
            }
        });

    Target Compile => _ => _
        .DependsOn(Restore, VerifyFormat)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Pack => _ => _
        .After(Compile)
        .Produces(PackagesDirectory / "*.nupkg")
        .Produces(PackagesDirectory / "*.snupkg")
        .Requires(() => Configuration.Equals(Configuration.Release))
        .Executes(() =>
        {
            DotNetPack(_ => _
                .Apply(PackSettings));

            ReportSummary(_ => _
                .AddPair("Packages", PackagesDirectory.GlobFiles("*.nupkg").Count.ToString()));
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .OnlyWhenStatic(() => IsTag && IsServerBuild)
        .Requires(() => NugetKey)
        .Requires(() => Configuration.Equals(Configuration.Release))
        .Executes(() =>
        {
            Log.Information("Running push to packages directory.");

            Assert.True(!string.IsNullOrEmpty(NugetKey));

            PackagesDirectory.GlobFiles("*.nupkg")
                .ForEach(x =>
                {
                    x.NotNull();
                    DotNetNuGetPush(s => s
                        .SetTargetPath(x)
                        .SetSource(NugetApiUrl)
                        .SetApiKey(NugetKey)
                        .EnableSkipDuplicate()
                    );
                });
        });

    Target PushGithubNuget => _ => _
        .DependsOn(Pack)
        .OnlyWhenStatic(() => IsTag && IsServerBuild)
        .Requires(() => GithubToken)
        .Requires(() => Configuration.Equals(Configuration.Release))
        .Executes(() =>
        {
            Log.Information("Running push to packages directory.");

            Assert.True(!string.IsNullOrEmpty(GithubToken));

            PackagesDirectory.GlobFiles("*.nupkg")
                .ForEach(x =>
                {
                    x.NotNull();
                    DotNetNuGetPush(s => s
                        .SetTargetPath(x)
                        .SetSource($"https://nuget.pkg.github.com/{GitHubActions.Instance.RepositoryOwner}/index.json")
                        .SetApiKey(GithubToken)
                        .EnableSkipDuplicate()
                    );
                });
        });

    Configure<DotNetPackSettings> PackSettings => _ => _
        .SetProject(Solution)
        .SetConfiguration(Configuration)
        .SetNoBuild(SucceededTargets.Contains(Compile))
        .SetOutputDirectory(PackagesDirectory);
}
