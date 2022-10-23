using GearsMonoRepoSample.Finance.Web.Api.Brokers.Storages;
using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using GearsMonoRepoSample.Finance.Web.Api.Services.Foundations.Expenses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace GearsMonoRepoSample.Finance.Tests.Unit.Services.Foundations.Expenses
{
    public partial class ExpenseServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IExpenseService expenseService;

        public ExpenseServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.expenseService = new ExpenseService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static Expense CreateRandomExpense() =>
            CreateExpenseFiller().Create();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        private static IQueryable<Expense> CreateRandomExpenses() => 
            CreateExpenseFiller().Create(GetRandomNumber()).AsQueryable();



        private static Filler<Expense> CreateExpenseFiller()
        {
            var filler = new Filler<Expense>();
            Guid expenseId = Guid.NewGuid();

            filler.Setup()
                .OnProperty(expense => expense.Id).Use(expenseId);

            return filler;
        }

    }
}
