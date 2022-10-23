using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using GearsMonoRepoSample.Finance.Web.Api.Services.Foundations.Expenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Finance.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : RESTFulController
    {
        private readonly IExpenseService expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<IQueryable<Expense>> GetAllExpenses()
        {
            try
            {
                IQueryable<Expense> storageExpenses =
                    this.expenseService.RetrieveAllExpenses();
                return Ok(storageExpenses);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{expenseId}")]
        public ActionResult<Expense> GetExpense(Guid expenseId)
        {
            try
            {
                Expense storageExpense =
                    this.expenseService.RetrieveExpenseById(expenseId);

                return Ok(storageExpense);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Expense> PostExpense(Expense expense)
        {
            try
            {
                Expense addedExpense =
                    this.expenseService.AddExpense(expense);

                return Created(addedExpense);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Expense> PutExpense(Expense expense)
        {
            try
            {
                Expense modifiedExpense =
                    this.expenseService.ModifyExpense(expense);

                return Ok(modifiedExpense);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<Expense> DeleteExpense(Expense expense)
        {
            try
            {
                Expense deletedExpense =
                    this.expenseService.RemoveExpense(expense);
                return Ok(expense);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
