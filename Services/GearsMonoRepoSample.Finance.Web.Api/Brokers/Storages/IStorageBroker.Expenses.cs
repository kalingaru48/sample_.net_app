using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GearsMonoRepoSample.Finance.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Expense InsertExpense(Expense expense);
        IQueryable<Expense> SelectAllExpenses();
        Expense SelectExpenseById(Guid expenseId);
        Expense UpdateExpense(Expense expense);
        Expense DeleteExpense(Expense expense);
    }
}
