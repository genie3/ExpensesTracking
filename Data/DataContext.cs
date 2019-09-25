using ExpensesTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Project> Projects { get; set; }

     
    }
}