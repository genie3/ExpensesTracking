using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
    }
}
