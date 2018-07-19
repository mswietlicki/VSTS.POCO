using System.Collections.Generic;
using System.Threading.Tasks;
using VSTS.POCO.WorkItems.Model;

namespace VSTS.POCO.WorkItems
{
    public interface IVstsWorkItemClient : IVstsClient
    {
        Task<IReadOnlyCollection<WorkItem>> GetWorkItemsAsync(IEnumerable<int> ids);
        Task<WorkItem> GetWorkItemAsync(int id);
        Task<WorkItem> CreateWorkItemAsync(WorkItem workItem, string project);
    }
}