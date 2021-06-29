using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace DefaultBlazor.Desktop.Maui {
    public class Startup : IStartup {
        public void Configure(IAppHostBuilder appBuilder) {
#pragma warning disable CA1416 // Validate platform compatibility
            appBuilder
                .RegisterBlazorMauiWebView(typeof(Startup).Assembly)
                .UseMicrosoftExtensionsServiceProviderFactory()
                .UseMauiApp<App>()
                //.ConfigureFonts(fonts => {
                //    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                //})
                .ConfigureServices(services => {
                    services.AddBlazorWebView();
                    Common.App.Setup.ConfigureSerices(services);
                });
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}