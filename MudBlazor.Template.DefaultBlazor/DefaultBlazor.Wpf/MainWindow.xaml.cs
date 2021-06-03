using DefaultBlazor.Wpf.Data;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Net.Http;
using System.Windows;

namespace DefaultBlazor.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddMudServices();
            serviceCollection.AddSingleton<HttpClient>();
            serviceCollection.AddSingleton<WeatherForecastService>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
            InitializeComponent();
        }
    }
}
