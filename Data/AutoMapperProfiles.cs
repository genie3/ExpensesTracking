using AutoMapper;
using ExpensesTracking.Dtos;
using ExpensesTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Data
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Expense, ExpensesForListDto>();
        }
    }
}
