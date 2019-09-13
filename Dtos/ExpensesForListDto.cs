using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Dtos
{
    public class ExpensesForListDto
    {
        public int Id { get; set; }
        public string ExpenseDate {get ; set; }
        public string Customer { get; set; }
        public string Project { get; set; }
        public float Amount { get; set; }
        
    }
}
