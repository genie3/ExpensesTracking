
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "Customer")]
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
