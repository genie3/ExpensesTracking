using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Data
{
    interface ISoftDelete
    {
        Boolean IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
