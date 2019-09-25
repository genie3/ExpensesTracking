using ExpensesTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracking.Data
{
    public interface IExpensesRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity, int? userId) where T : class;

        void Update<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpense(int id);

        Task<IEnumerable<Project>> GetProjects();

    }
}
