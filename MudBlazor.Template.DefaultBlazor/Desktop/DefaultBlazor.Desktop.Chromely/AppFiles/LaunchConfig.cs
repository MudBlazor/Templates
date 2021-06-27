using Chromely.Browser;
using Chromely.Core.Configuration;
using System.Linq;

namespace DefaultBlazor.Desktop.Chromely.AppFiles {

    /// <summary> Launch Configuration. </summary>
    public class LaunchConfig {

        /// <summary> Tracks the TCP Port in use. </summary>
        /// <value> The TCP port for IPC. </value>
        public int Port { get; protected set; }

        /// <summary> Tracks the Application URLs in use. </summary>
        /// <value> The Application URLs in use. </value>
        public string[] AppUrls { get; protected set; }

        /// <summary> The command line arguments. </summary>
        /// <value> The command line arguments. </value>
        public string[] Args { get; protected set; }

        /// <summary> Tracks the chromely configuration. </summary>
        /// <value> The chromely configuration. </value>
        public IChromelyConfiguration ChromelyConfig { get; protected set; }

        /// <summary> This tells us if we're running as a child thread or the main thread. </summary>
        /// <value> The type of the chromely process. </value>
        public ProcessType ChromelyProcessType { get; protected set; }

        /// <summary> Constructor. </summary>
        /// <param name="args"> The command line arguments. </param>
        public LaunchConfig(string[] args) {
            Args = args;
            Setup(args);
        }

        /// <summary> Gets the chromely configuration. </summary>
        /// <returns> The chromely configuration. </returns>
        public void Setup(string[] args) {
            ChromelyProcessType = ClientAppUtils.GetProcessType(args);
            ChromelyConfig = DefaultConfiguration.CreateForRuntimePlatform();
            ChromelyConfig.WindowOptions.Title = "Title Window";
            ChromelyConfig.WindowOptions.RelativePathToIconFile = "wwwroot/favicon.ico";
            // browser dev tools
            ChromelyConfig.DebuggingMode = true;

            // The App URL only has to be added in the main host app, not in any child threads loaded by Chromely
            // So only search for an available port on the main thread
            if (ChromelyProcessType == ProcessType.Browser) {
                Port = ClientUrlHelper.GetAvailablePort();
                AppUrls = ClientUrlHelper.GetLocalHttpUrls(Port).ToArray();
                ChromelyConfig.StartUrl = AppUrls.First();
            }
        }
    }
}
