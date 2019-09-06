﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
        public int UserId { get; set; }
    }
}