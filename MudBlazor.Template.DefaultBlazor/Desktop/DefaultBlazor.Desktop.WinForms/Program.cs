using DefaultBlazor.Desktop.WinForms.App;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace DefaultBlazor.Desktop.WinForms {

    /// <summary> Main Program entry point. </summary>
    public static class Program
    {
        /// <summary> The list of services used to build the Service Provider. </summary>
        /// <value> The Services. </value>
        public static ServiceCollection Services { get; set; }

        /// <summary> The Service Provider in use. </summary>
        /// <value> The service provider. </value>
        public static ServiceProvider ServicesProvider { get; set; }

        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, error) => {
                MessageBox.Show(text: error.ExceptionObject.ToString(), caption: "Error");
            };
            SetupServices();
            SetupDialog();
            Application.Run(new MainDialog());
        }

        /// <summary> Sets up the dialog. </summary>
        public static void SetupDialog() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary> Sets up the services. </summary>
        public static void SetupServices() {
            Services = new ServiceCollection();
            Services.AddBlazorWebView();
            Shared.App.Setup.ConfigureSerices(Services);
            ServicesProvider = Services.BuildServiceProvider();
        }
    }
}
