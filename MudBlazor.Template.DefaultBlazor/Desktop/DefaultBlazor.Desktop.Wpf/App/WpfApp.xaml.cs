using System;
using System.Windows;

namespace DefaultBlazor.Desktop.Wpf.App {

    /// <summary> Interaction logic for App.xaml. </summary>
    public partial class WpfApp : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            AppDomain.CurrentDomain.UnhandledException += (sender, error) => {
                MessageBox.Show(error.ExceptionObject.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }
    }
}
