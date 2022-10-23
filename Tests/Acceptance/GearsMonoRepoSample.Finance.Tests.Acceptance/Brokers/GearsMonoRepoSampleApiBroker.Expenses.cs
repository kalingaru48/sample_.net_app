using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsMonoRepoSample.Finance.Tests.Acceptance.Brokers
{
    public partial class GearsMonoRepoSampleApiBroker
    {
        private const string expensesRelativeUrl = "api/expenses";

        public async ValueTask<Expense> PostExpenseAsync(Expense expense) => 
            await this.apiFactoryClient.PostContentAsync(expensesRelativeUrl, expense);

        public async ValueTask<Expense> GetExpenseByIdAsync(Guid expenseId) =>
            await this.apiFactoryClient.GetContentAsync<Expense>($"{expensesRelativeUrl}/{expenseId}");

        public async ValueTask<List<Expense>> GetAllExpensesAsync() =>
            await this.apiFactoryClient.GetContentAsync<List<Expense>>(expensesRelativeUrl);

        public async ValueTask<Expense> PutExpenseAsync(Expense expense) => 
            await this.apiFactoryClient.PutContentAsync(expensesRelativeUrl, expense);

       
    }
}
