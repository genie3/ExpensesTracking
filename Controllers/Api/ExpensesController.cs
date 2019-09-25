using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesTracking.Data;
using ExpensesTracking.Dtos;
using ExpensesTracking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExpensesTracking.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepository _repo;
        private readonly IMapper _mapper;

        public ExpensesController(IExpensesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        // GET: api/Expenses
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _repo.GetExpenses();
            var expensesToReturn = _mapper.Map<IEnumerable<ExpensesForListDto>>(expenses);
            return Ok(expensesToReturn);
        }

        // GET: api/Expenses/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetExpense(int id)
        {
            var expense = await _repo.GetExpense(id);
            if (expense == null)
                return NotFound();
            var expenseToReturn = _mapper.Map<ExpensesForListDto>(expense);
            return Ok(expenseToReturn);
        }

        // POST: api/Expenses
        [HttpPost]
        public IActionResult CreateExpense(Expense expense)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _repo.Add(expense);
            _repo.SaveAll();

           // var expenseToReturn = _mapper.Map<ExpensesForListDto>(expense);
            return Created(new Uri(Request.Path + "/"+expense.Id), expense);

        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, Expense expense)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _repo.Update(expense);
            _repo.SaveAll();
            return RedirectToAction("Index");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var expense = _repo.GetExpense(id);
            if (expense == null)
                return;
            _repo.Delete(expense);
            _repo.SaveAll();

        }
    }
}
