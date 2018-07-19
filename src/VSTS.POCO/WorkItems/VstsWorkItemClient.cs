using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VSTS.POCO.WorkItems.Model;

namespace VSTS.POCO.WorkItems
{
    public class VstsWorkItemClient : IVstsWorkItemClient
    {
        private readonly IVstsHttpClient _vsts;
        private readonly IVstsMapper<WorkItem> _workItemMapper;

        public VstsWorkItemClient(IVstsHttpClient vsts, IVstsMapper<WorkItem> workItemMapper)
        {
            _vsts = vsts;
            _workItemMapper = workItemMapper;
        }

        public async Task<IReadOnlyCollection<WorkItem>> GetWorkItemsAsync(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<WorkItem> GetWorkItemAsync(int id, WorkItemExpand expand = WorkItemExpand.None)
        {
            var content = await _vsts.GetStringAsync($"/_apis/wit/workitems/{id}?$expand={expand.ToString()}");
            return _workItemMapper.Map(content);
        }

        public async Task<WorkItem> CreateWorkItemAsync(WorkItem workItem, string project)
        {
            throw new System.NotImplementedException();
        }
    }
}