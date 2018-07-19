using System;
using Microsoft.Extensions.DependencyInjection;

namespace VSTS.POCO
{
    public class VstsClientFactory : IVstsClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public VstsClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Create<T>() where T : IVstsClient
        {
            return _serviceProvider.GetService<T>();
        }
    }
}