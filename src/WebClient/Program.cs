using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            ICustomerReader customerReader = serviceProvider.GetRequiredService<ICustomerReader>();
            ICustomerWriter customerWriter = serviceProvider.GetRequiredService<ICustomerWriter>();
            ICustomerCreator customerCreator = serviceProvider.GetRequiredService<ICustomerCreator>();

            while (true)
            {
                Console.WriteLine($"1 - Поиск клиента по идентификатору{Environment.NewLine}2 - Создание нового клиента");

                int menuItem = int.Parse(Console.ReadLine());

                switch (menuItem)
                {
                    case 1:
                        Console.WriteLine("Введите идентификатор клиента");
                        int customerID = int.Parse(Console.ReadLine());
                        Customer customer = customerReader.Read(customerID).GetAwaiter().GetResult();
                        customerWriter.WriteCustomerOnConsole(customer);
                        break;
                    case 2:
                        long newCustomerID = customerCreator.CreateRandomCustomer().GetAwaiter().GetResult();
                        if (newCustomerID == -1)
                            Console.WriteLine("Пользователь с таким идентификатором уже существует");

                        customer = customerReader.Read(newCustomerID).GetAwaiter().GetResult();
                        customerWriter.WriteCustomerOnConsole(customer);

                        break;
                    default:
                        break;
                }
            }

        }

        private static Customer RandomCustomer()
        {
            return new Customer()
            {
                Firstname = "e",
                Id = 1,
                Lastname = "d"
            };
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient().
                AddSingleton<ICustomerReader, CustomerReader>().
                AddSingleton<ICustomerWriter, CustomerWriter>().
                AddSingleton<ICustomerCreator, CustomerCreator>();
        }
    }
}