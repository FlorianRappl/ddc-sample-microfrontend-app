using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace ddc_sample_app.Client
{
    public static class AssemblyLoader
    {
        public static async Task<IEnumerable<Assembly>> LoadAssembliesAsync(HttpClient client, WebAssemblyHostBuilder builder)
        {
            var isDev = builder.HostEnvironment.IsDevelopment();
            var filePaths = await client.GetFromJsonAsync<string[]>("/api/modules");
            var dllPaths = filePaths?.Where(f => f.EndsWith(".dll")) ?? Enumerable.Empty<string>();
            var assemblies = new List<Assembly> { Assembly.GetAssembly(typeof(App)) };

            foreach (var dllPath in dllPaths)
            {
                var pdbPath = dllPath.Substring(0, dllPath.Length - 4) + ".pdb";
                var shouldLoadDebug = isDev && filePaths!.Contains(pdbPath);

                await using var contentStream = await client.GetStreamAsync(dllPath);
                await using var debugStream = shouldLoadDebug ? await client.GetStreamAsync(pdbPath) : null;

                assemblies.Add(AssemblyLoadContext.Default.LoadFromStream(contentStream, debugStream));
            }

            return assemblies;
        }
    }
}
