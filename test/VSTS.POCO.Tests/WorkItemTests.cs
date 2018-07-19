using Microsoft.Extensions.DependencyInjection;
using Moq;
using VSTS.POCO.WorkItems;
using VSTS.POCO.WorkItems.Model;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace VSTS.POCO.Tests
{
    public class WorkItemTests
    {
        [Fact]
        public void GetVstsWorkItemClientWhenFromIVstsClientFactory()
        {
            var serviceProvider = new ServiceCollection().AddVsts("test", "").BuildServiceProvider();
            var vstsClientFactory = new VstsClientFactory(serviceProvider);
            var vstsWorkItemClient = vstsClientFactory.Create<IVstsWorkItemClient>();

            Assert.NotNull(vstsWorkItemClient);
            Assert.IsType<VstsWorkItemClient>(vstsWorkItemClient);
        }

        [Fact]
        public async Task VstsWorkItemClientClasWorkItemMapper()
        {
            var vsts = new Mock<IVstsHttpClient>();
            var workItemMapper = new Mock<IVstsMapper<WorkItem>>();
            workItemMapper.Setup(_ => _.Map(It.IsAny<string>())).Returns(new WorkItem());
            var vstsWorkItemClient = new VstsWorkItemClient(vsts.Object, workItemMapper.Object);

            var workItem = await vstsWorkItemClient.GetWorkItemAsync(0);

            Assert.NotNull(workItem);
        }

        [Fact]
        public async Task VstsWorkItemClientCallsGetStringAsync()
        {
            var vsts = new Mock<IVstsHttpClient>();
          
            var workItemMapper = new Mock<IVstsMapper<WorkItem>>();
            var vstsWorkItemClient = new VstsWorkItemClient(vsts.Object, workItemMapper.Object);

            var workItem = await vstsWorkItemClient.GetWorkItemAsync(0);

            vsts.Verify(_ => _.GetStringAsync(It.IsAny<string>()));
        }
    }
}
