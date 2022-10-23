using System;

namespace GearsMonoRepoSample.Finance.Web.Api.Models.Expenses
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
