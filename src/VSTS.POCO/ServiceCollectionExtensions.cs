using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using VSTS.POCO.WorkItems;

namespace VSTS.POCO
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVsts(this IServiceCollection services, string accountName, string accessToken)
        {
            services.AddHttpClient();

            services.AddTransient<IVstsWorkItemClient, VstsWorkItemClient>();
            services.AddTransient<VstsWorkItemClient, VstsWorkItemClient>();

            return services;
        }
    }
}
