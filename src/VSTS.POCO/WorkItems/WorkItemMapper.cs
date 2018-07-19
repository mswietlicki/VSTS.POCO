using VSTS.POCO.WorkItems.Model;

namespace VSTS.POCO.WorkItems
{
    public class WorkItemMapper : IVstsMapper<WorkItem>
    {
        public WorkItem Map(string json)
        {
            return new WorkItem();
        }
    }
}