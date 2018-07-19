using System;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VSTS.POCO.WorkItems;

namespace VSTS.POCO
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVsts(this IServiceCollection services, string accountName, string accessToken)
        {
            services.AddHttpClient<IVstsHttpClient, VstsHttpClient>(client =>
            {
                client.BaseAddress = new Uri($"https://{accountName}.visualstudio.com");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($":{accessToken}")));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            
            services.AddTransient<IVstsWorkItemClient, VstsWorkItemClient>();
            services.AddTransient<VstsWorkItemClient, VstsWorkItemClient>();

            var assembly = Assembly.GetExecutingAssembly();
            services.Scan(s =>
            {
                s.FromAssemblies(assembly)
                    .AddClasses(c => c.AssignableTo(typeof(IVstsMapper<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });

            return services;
        }
    }
}
