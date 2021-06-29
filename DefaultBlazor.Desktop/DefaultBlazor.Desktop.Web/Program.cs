using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DefaultBlazor.Desktop.Web {

    /// <summary> Main Program. </summary>
    public class Program {

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> The arguments. </param>
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary> Creates host builder. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> The new host builder. </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
