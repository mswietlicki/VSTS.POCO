using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VSTS.POCO
{
    public interface IVstsHttpClient
    {
        Task<string> GetStringAsync(string uri);
    }
    public class VstsHttpClient : IVstsHttpClient
    {
        private readonly HttpClient _client;

        public VstsHttpClient(HttpClient client)
        {
            _client = client;
        }

        public  Task<string> GetStringAsync(string uri)
        {
            return _client.GetStringAsync(uri);
        }
    }
}