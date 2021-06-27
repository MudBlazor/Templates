using DefaultBlazor.Desktop.Common.Data;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Net.Http;

namespace DefaultBlazor.Desktop.Common.App {
    public class Setup {

        /// <summary> Configure serices. </summary>
        /// <param name="services"> The services. </param>
        public static void ConfigureSerices(IServiceCollection services) {
            services.AddMudServices();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<WeatherForecastService>();
        }

    }
}
