using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracking.Data
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly DataContext _context;
        public ExpensesRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity, int? userId) where T : class
        {
            if(entity is ISoftDelete){
                ISoftDelete e = (ISoftDelete)entity;
                e.DeletedDate = DateTime.Now;
                e.IsDeleted = true;
                e.DeletedBy = userId;
            }
            else
            {
                _context.Remove(entity);
            }
            
        }

        public Task<Expense> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            var expenses = await _context.Expenses.Where(x=>x.IsDeleted == false).Include(p => p.Project).Include(c => c.Project.Customer).ToListAsync();

            return expenses;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
