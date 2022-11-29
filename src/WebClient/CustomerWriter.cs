using System;

namespace WebClient
{
    public class CustomerWriter : ICustomerWriter
    {
        public void WriteCustomerOnConsole(Customer customer)
        {
            if (customer == null)
                Console.WriteLine("Клиент не найден");
            else
                Console.WriteLine($"{nameof(customer.Lastname)} - {customer.Lastname}{Environment.NewLine}{nameof(customer.Firstname)} - {customer.Firstname}" +
                    $"{Environment.NewLine}{nameof(customer.Id)} - {customer.Id}");
        }
    }
}
