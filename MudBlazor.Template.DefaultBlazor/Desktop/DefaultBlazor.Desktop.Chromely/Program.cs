using Chromely.Browser;
using Chromely.Core;
using Chromely.Core.Configuration;
using DefaultBlazor.Desktop.Chromely.AppFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace DefaultBlazor.Desktop.Chromely {

    /// <summary> Main Program. </summary>
    public class Program {

        /// <summary> Chromely Configuration. </summary>
        /// <value> Chromely Configuration. </value>
        public static LaunchConfig LaunchConfig { get; set; }

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> The arguments. </param>
        public static void Main(string[] args) {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_CHROMELY") != "false") {
                // Run as desktop application
                RunDesktop(args);
            }
            else {
                // Run as website
                RunWeb(args);
            }
        }

        /// <summary> Run the application as a desktop application. </summary>
        /// <param name="args"> The arguments. </param>
        private static void RunDesktop(string[] args) {
            LaunchConfig = new LaunchConfig(args);
            // Setup the Web Host Builder to listen on a port
            // But only do this when the parent host process is launched initially
            // not when Chromely launches itself as a child process
            if (LaunchConfig.ChromelyProcessType == ProcessType.Browser) {
                var port = LaunchConfig.Port;
                var appurls = LaunchConfig.AppUrls;
                var runner = new ChromelyTaskRunner(() =>
                   CreateHostBuilder(args, appurls).Build().Run(), 
                   port);
                AppDomain.CurrentDomain.ProcessExit += runner.ProcessExit;
                runner.Launch();
            }
            ChromelyBootstrap(args);

        }

        /// <summary> Run the application as a website. </summary>
        /// <param name="args"> The arguments. </param>
        private static void RunWeb(string[] args) {
            var port = ClientUrlHelper.GetAvailablePort();
            var appurls = ClientUrlHelper.GetLocalHttpUrls(port).ToArray();
            CreateHostBuilder(args, appurls).Build().Run();
        }

        /// <summary> Creates web host builder. </summary>
        /// <param name="config"> Configuration settings</param>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns> The new web host builder. </returns>
        private static IHostBuilder CreateHostBuilder(string[] args, string[] appurls) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder
                    .UseStartup<Startup>()
                    .UseUrls(appurls);
                });

        /// <summary> Bootstrap the Chromely browser application window. </summary>
        public static void ChromelyBootstrap(string[] args) {
            try {
                AppBuilder.Create()
                    .UseConfig<DefaultConfiguration>(LaunchConfig.ChromelyConfig)
                    .UseApp<LocalChromelyApp>()
                    .Build()
                    .Run(args);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
