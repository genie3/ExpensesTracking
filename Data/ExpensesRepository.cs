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
            _context.Add(entity);
        }

        public void Delete<T>(T entity, int? userId) where T : class
        {
            if (entity is ISoftDelete)
            {
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

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<Expense> GetExpense(int id)
        {
            var expense = await _context.Expenses.Include(p => p.Project.Customer).SingleOrDefaultAsync(x => x.Id == id);
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {

            var expenses = await _context.Expenses
            .Include(p => p.Project.Customer)
            .Where(x => x.IsDeleted == false).ToListAsync();

            return expenses;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            var projects = await _context.Projects.Include(c => c.Customer).ToListAsync();

            return projects;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
