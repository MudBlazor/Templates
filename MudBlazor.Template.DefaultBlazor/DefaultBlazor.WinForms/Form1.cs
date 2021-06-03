using DefaultBlazor.WinForms.Data;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Net.Http;
using System.Windows.Forms;

namespace DefaultBlazor.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddMudServices();
            serviceCollection.AddSingleton<HttpClient>();
            serviceCollection.AddSingleton<WeatherForecastService>();
            InitializeComponent();

            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider(),
            };
            blazor.RootComponents.Add<App>("#app");
            Controls.Add(blazor);
        }

    }
}
