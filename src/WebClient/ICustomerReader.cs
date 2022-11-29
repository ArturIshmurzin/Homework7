using System.Threading.Tasks;

namespace WebClient
{
    public interface ICustomerReader
    {
        Task<Customer> Read(long id);
    }
}
