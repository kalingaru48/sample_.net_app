using GearsMonoRepoSample.Finance.Web.Api.Brokers.Storages;
using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Finance.Web.Api.Services.Foundations.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IStorageBroker storageBroker;

        public ExpenseService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public Expense AddExpense(Expense expense)
        {
            return this.storageBroker.InsertExpense(expense);
        }

        public Expense ModifyExpense(Expense expense)
        {
            return this.storageBroker.UpdateExpense(expense);
        }

        public Expense RemoveExpense(Expense expense)
        {
            return this.storageBroker.DeleteExpense(expense);
        }

        public IQueryable<Expense> RetrieveAllExpenses()
        {
            return this.storageBroker.SelectAllExpenses();
        }

        public Expense RetrieveExpenseById(Guid expenseId)
        {
            return this.storageBroker.SelectExpenseById(expenseId);
        }
    }
}
