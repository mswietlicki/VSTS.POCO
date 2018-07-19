namespace VSTS.POCO
{
    public interface IVstsClientFactory
    {
        T Create<T>() where T : IVstsClient;
    }
}