using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ddc_sample_app.Shared
{
    public static class Extensions
    {
        public static void AddMicrofrontends(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var fragmentMap = new FragmentMap();
            var collection = new ComponentCollection();

            foreach (var assembly in assemblies)
            {
                var components = assembly
                   .GetTypes()
                   .Where(t => t.GetInterfaces().Contains(typeof(IComponent)));

                collection.AddRange(components);

                foreach (var component in components)
                {
                    var attributes = component.GetCustomAttributes<FragmentAttribute>();

                    foreach (var attribute in attributes)
                    {
                        var slotName = attribute.FragmentSlot;

                        if (slotName is not null)
                        {
                            fragmentMap.AddComponent(slotName, component);
                        }
                    }
                }

                services.ConfigureMicrofrontend(assembly);
            }

            services.AddScoped<RouteManager>();
            services.AddScoped(_ => collection);
            services.AddScoped(_ => fragmentMap);
        }

        private static void ConfigureMicrofrontend(this IServiceCollection services, Assembly assembly)
        {
            var configureServicesMethod = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals("Microfrontend", StringComparison.Ordinal))
                ?.GetMethod("ConfigureServices", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(IServiceCollection) }, null);

            configureServicesMethod?.Invoke(null, new object[] { services });
        }
    }
}
