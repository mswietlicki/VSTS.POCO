using Microsoft.Extensions.DependencyInjection;
using VSTS.POCO.WorkItems;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace VSTS.POCO.Tests.Integration
{
    public class IntegrationWorkItemTests
    {
        [Fact]
        public async Task VstsWorkItemClientClasWorkItemMapper()
        {
            var serviceProvider = new ServiceCollection().AddVsts("test", "").BuildServiceProvider();
            var vstsClientFactory = new VstsClientFactory(serviceProvider);
            var vstsWorkItemClient = vstsClientFactory.Create<IVstsWorkItemClient>();

            var workItem = await vstsWorkItemClient.GetWorkItemAsync(61616);

            Assert.NotNull(workItem);
        }
    }
}
