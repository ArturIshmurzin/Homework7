using System.Threading.Tasks;

namespace WebClient
{
    public interface ICustomerCreator
    {
        Task<long> CreateRandomCustomer();
    }
}
