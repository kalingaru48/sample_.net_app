using FluentAssertions;
using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GearsMonoRepoSample.Finance.Tests.Unit.Services.Foundations.Expenses
{
    public partial class ExpenseServiceTests
    {
        [Fact]
        public void ShouldRetreiveAllExpenses()
        {
            // given
            IQueryable<Expense> randomExpenses = CreateRandomExpenses();
            IQueryable<Expense> storageExpenses = randomExpenses;
            IQueryable<Expense> expectedExpenses = storageExpenses;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllExpenses())
                .Returns(storageExpenses);

            // when
            IQueryable<Expense> actualExpenses = 
                this.expenseService.RetrieveAllExpenses();

            // then 
            actualExpenses.Should().BeEquivalentTo(expectedExpenses);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllExpenses(),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
