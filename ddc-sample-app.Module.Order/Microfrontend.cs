using Microsoft.Extensions.DependencyInjection;

namespace ddc_sample_app.Module.Order
{
    public static class Microfrontend
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICartRepository, InMemoryCartRepository>();
        }
    }
}
