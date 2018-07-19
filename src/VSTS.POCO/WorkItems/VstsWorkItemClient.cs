using System.Collections.Generic;
using System.Threading.Tasks;
using VSTS.POCO.WorkItems.Model;

namespace VSTS.POCO.WorkItems
{
    public class VstsWorkItemClient : IVstsWorkItemClient
    {

        public async Task<IReadOnlyCollection<WorkItem>> GetWorkItemsAsync(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<WorkItem> GetWorkItemAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<WorkItem> CreateWorkItemAsync(WorkItem workItem, string project)
        {
            throw new System.NotImplementedException();
        }
    }
}