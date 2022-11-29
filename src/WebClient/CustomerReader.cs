using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebClient
{
    public class CustomerReader : ICustomerReader
    {
        public CustomerReader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private readonly IHttpClientFactory _httpClientFactory;

        public async Task<Customer> Read(long id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            var result = await httpClient.GetAsync($"https://localhost:5001/customers/{id}");

            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;


            return JsonConvert.DeserializeObject<Customer>(await result.Content.ReadAsStringAsync());
        }
    }
}
