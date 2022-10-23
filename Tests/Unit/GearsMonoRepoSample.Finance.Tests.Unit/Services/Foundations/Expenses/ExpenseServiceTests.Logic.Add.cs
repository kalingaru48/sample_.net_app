using FluentAssertions;
using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using Moq;
using Xunit;

namespace GearsMonoRepoSample.Finance.Tests.Unit.Services.Foundations.Expenses
{
    public partial class ExpenseServiceTests
    {
        [Fact]
        public void ShouldAddExpense()
        {
            // given
            Expense randomExpense = CreateRandomExpense();

            Expense inputExpense = randomExpense;
            Expense storageExpense = inputExpense;
            Expense expectedExpense = storageExpense;

            this.storageBrokerMock.Setup(broker =>
                broker.InsertExpense(inputExpense))
                .Returns(storageExpense);

            // when 
            Expense actualExpense = 
                this.expenseService.AddExpense(inputExpense);


            // then 
            actualExpense.Should().BeEquivalentTo(expectedExpense);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertExpense(inputExpense),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
