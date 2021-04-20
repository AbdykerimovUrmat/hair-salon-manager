using HairSalon.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HairSalon.Common.Extensions
{
    public static class IServiceColletionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ClientService>();
        }
    }
}
