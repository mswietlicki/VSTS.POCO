using System;
using Microsoft.Extensions.DependencyInjection;
using VSTS.POCO.WorkItems;
using Xunit;

namespace VSTS.POCO.Tests
{
    public class WorkItemTests
    {
        [Fact]
        public void GetVstsWorkItemClientWhenFromIVstsClientFactory()
        {
            var serviceProvider = new ServiceCollection().AddVsts(null, null).BuildServiceProvider();
            var vstsClientFactory = new VstsClientFactory(serviceProvider);
            var vstsWorkItemClient = vstsClientFactory.Create<IVstsWorkItemClient>();

            Assert.NotNull(vstsWorkItemClient);
            Assert.IsType<VstsWorkItemClient>(vstsWorkItemClient);
        }
    }
}
