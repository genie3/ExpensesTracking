using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesTracking.Data;
using ExpensesTracking.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracking.Controllers
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
        public async Task<IActionResult> GetAsync()
        {
            var expenses = await _repo.GetExpenses();
            var expensesToReturn = _mapper.Map<IEnumerable<ExpensesForListDto>>(expenses);
            return Ok(expensesToReturn);
        }

        // GET: api/Expenses/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Expenses
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
