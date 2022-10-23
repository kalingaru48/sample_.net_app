using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Finance.Web.Api.Services.Foundations.Expenses
{
    public interface IExpenseService
    {
        Expense AddExpense(Expense expense);
        IQueryable<Expense> RetrieveAllExpenses();
        Expense RetrieveExpenseById(Guid expenseId);
        Expense ModifyExpense(Expense expense);
        Expense RemoveExpense(Expense expense);
    }
}
