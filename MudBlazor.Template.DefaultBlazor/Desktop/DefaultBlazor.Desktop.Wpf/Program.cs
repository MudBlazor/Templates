using DefaultBlazor.Desktop.Wpf.App;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DefaultBlazor.Desktop.Wpf {

    /// <summary> Main Program entry point. </summary>
    public static class Program {

        /// <summary> The list of services used to build the Service Provider. </summary>
        /// <value> The Services. </value>
        public static ServiceCollection Services { get; set; }

        /// <summary> The Service Provider in use. </summary>
        /// <value> The service provider. </value>
        public static ServiceProvider ServicesProvider { get; set; }

        /// <summary> The main winForms Dialog. </summary>
        /// <value> The main winForms Dialog. </value>
        public static WpfApp Dialog { get; set; }

        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        public static void Main() {
            SetupServices();
            SetupDialog();
            Dialog.Run();
        }

        /// <summary> Sets up the dialog. </summary>
        public static void SetupDialog() {
            Dialog = new WpfApp();
            Dialog.InitializeComponent();
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
