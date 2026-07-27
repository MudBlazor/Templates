using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace MudBlazor.Template.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddMudServices();

#if (IndividualLocalAuth)
        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        #endif
        await builder.Build().RunAsync();
    }
}
