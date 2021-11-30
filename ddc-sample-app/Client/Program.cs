using ddc_sample_app.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ddc_sample_app.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            await Configure(builder);
            builder.RootComponents.Add<App>("#app");
            await builder.Build().RunAsync();
        }

        private static async Task Configure(WebAssemblyHostBuilder builder)
        {
            var client = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            builder.Services.AddScoped(sp => client);

            var assemblies = await AssemblyLoader.LoadAssembliesAsync(client, builder);
            builder.Services.AddMicrofrontends(assemblies);
        }
    }
}
