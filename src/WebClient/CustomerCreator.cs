using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class CustomerCreator : ICustomerCreator
    {
        public CustomerCreator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private readonly IHttpClientFactory _httpClientFactory;

        private Random random = new Random();

        public async Task<long> CreateRandomCustomer()
        {
            Customer customer = new Customer()
            {
                Firstname = RandomString(10),
                Id = random.Next(),
                Lastname = RandomString(10)
            };

            var client = _httpClientFactory.CreateClient();
            string json = JsonConvert.SerializeObject(customer);

            var result = await client.PostAsync("https://localhost:5001/customers", new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                return -1;

            return await result.Content.ReadFromJsonAsync<long>();
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
