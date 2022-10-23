using FluentAssertions;
using Force.DeepCloner;
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
        public void ShouldModifyExpense()
        {
            // given
            Expense randomExpense = CreateRandomExpense();
            Expense inputExpense = randomExpense;
            Expense afterUpdateExpense = inputExpense;
            Expense expectedExpense = afterUpdateExpense;
            Expense beforeUpdateStorageExpense = randomExpense.DeepClone();

            Guid expenseId = randomExpense.Id;

            this.storageBrokerMock.Setup(broker => 
                broker.SelectExpenseById(expenseId))
                .Returns(beforeUpdateStorageExpense);

            this.storageBrokerMock.Setup(broker => 
                broker.UpdateExpense(inputExpense))
                .Returns(afterUpdateExpense);

            // when
            Expense actualExpense = this.expenseService.ModifyExpense(inputExpense);

            // then
            actualExpense.Should().BeEquivalentTo(expectedExpense);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateExpense(inputExpense), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
