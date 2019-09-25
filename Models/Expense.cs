using ExpensesTracking.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Expense : ISoftDelete 
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ExpenseDate { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
