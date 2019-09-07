using ExpensesTracking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Data
{
    public class Seed
    {
        public static void SeedCustomers(DataContext context)
        {
            if(!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("Data/CustomerSeedData.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach (var customer in customers)
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
            }
        }
    }
}
