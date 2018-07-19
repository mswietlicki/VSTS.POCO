using VSTS.POCO.WorkItems.Model;

namespace VSTS.POCO.WorkItems
{
    public interface IVstsMapper<T>
    {
        WorkItem Map(string json);
    }
}