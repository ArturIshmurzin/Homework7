using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers= new List<Customer>();

        public Customer Add(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> FindAsync(long id)
        {
            return Task.FromResult(customers.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> TryAddAsync(Customer entity)
        {
            if(customers.Any(x => x.Id == entity.Id))
                return Task.FromResult(false);

            customers.Add(entity);

            return Task.FromResult(true);
        }
    }
}
