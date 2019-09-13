using AutoMapper;
using ExpensesTracking.Dtos;
using ExpensesTracking.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Data
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Expense, ExpensesForListDto>()
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.Name))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Project.Customer.Name))
                .ForMember(dest => dest.ExpenseDate, opt => opt.MapFrom(src => src.ExpenseDate.ToString("MM/dd/yyyy")));
        }
    }
}
