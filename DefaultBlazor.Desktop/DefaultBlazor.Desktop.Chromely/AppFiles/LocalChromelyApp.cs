using Chromely;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultBlazor.Desktop.Chromely.AppFiles {

    /// <summary> A local chromely application. </summary>
    public class LocalChromelyApp : ChromelyBasicApp {

        /// <summary> Configure services. </summary>
        /// <param name="services"> The services. </param>
        public override void ConfigureServices(IServiceCollection services) {
            base.ConfigureServices(services);
            RegisterControllerAssembly(services, typeof(LocalChromelyApp).Assembly);
        }

    }
}
