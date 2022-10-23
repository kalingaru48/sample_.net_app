using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GearsMonoRepoSample.Finance.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public Expense InsertExpense(Expense expense)
        {
            this.expenses.Add(expense);
            return expense;
        }
        public IQueryable<Expense> SelectAllExpenses()
        {
            return this.expenses.AsQueryable();
        }

        public Expense SelectExpenseById(Guid expenseId)
        {
            return this.expenses.Find(expenses => expenses.Id == expenseId);
        }
        public Expense UpdateExpense(Expense expense)
        {
            this.DeleteExpense(expense);
            this.InsertExpense(expense);

            return expense;
        }

        public Expense DeleteExpense(Expense expense)
        {
            this.expenses.Remove(expense);

            return expense;
        }
    }
}

