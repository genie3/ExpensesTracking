using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Display(Name = "Project")]
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

     









    }
}
