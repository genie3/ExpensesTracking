using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public Customer Customer { get; set; }







    }
}
