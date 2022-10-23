using FluentAssertions;
using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using Moq;
using Xunit;

namespace GearsMonoRepoSample.Finance.Tests.Unit.Services.Foundations.Expenses
{
    public partial class ExpenseServiceTests
    {
        [Fact]
        public void ShouldRetrieveExpenseById()
        {
            // given
            Guid randomExpenseId = Guid.NewGuid();
            Guid inputExpenseId = randomExpenseId;

            Expense randomExpense = CreateRandomExpense();
            Expense storageExpense = randomExpense;
            Expense expectedExpense = storageExpense;

            this.storageBrokerMock.Setup(broker => 
                broker.SelectExpenseById(inputExpenseId))
                .Returns(storageExpense);

            // when 
            Expense actualExpense = 
                this.expenseService.RetrieveExpenseById(inputExpenseId);

            // then 
            actualExpense.Should().BeEquivalentTo(expectedExpense);

            this.storageBrokerMock.Verify(broker => 
                broker.SelectExpenseById(inputExpenseId),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
