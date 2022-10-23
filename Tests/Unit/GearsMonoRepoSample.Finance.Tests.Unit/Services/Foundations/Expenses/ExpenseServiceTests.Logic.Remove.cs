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
        public void ShouldRemoveExpense()
        {
            // given 
            Expense randomExpense = CreateRandomExpense();
            Guid randomExpenseId = Guid.NewGuid();
            Expense storageExpense = randomExpense;
            Expense expectedExpense = storageExpense;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectExpenseById(randomExpenseId))
                .Returns(storageExpense);

            this.storageBrokerMock.Setup(broker => 
                broker.DeleteExpense(storageExpense))
                .Returns(expectedExpense);

            // when
            Expense actualExpense = 
                this.expenseService.RemoveExpense(randomExpense);

            // then
            actualExpense.Should().BeEquivalentTo(expectedExpense);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteExpense(randomExpense),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
