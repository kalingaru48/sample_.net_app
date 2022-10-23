using GearsMonoRepoSample.Finance.Web.Api.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GearsMonoRepoSample.Finance.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        private readonly List<Expense> expenses;

        public StorageBroker()
        {
            this.expenses = ExpensesData();
        }


        private List<Expense> ExpensesData()
        {
            List<Expense> expenses = new List<Expense>
            {
                new Expense
                {
                    Id = new Guid("26f022d0-da29-4cf1-a798-a539510ebfdb"),
                    Name = "Electricity Bills",
                    Price = 20000.00m
                },
                new Expense
                {
                    Id = new Guid("da00f2a4-ba47-41a6-9897-8759f3cd4043"),
                    Name = "Maintanance",
                    Price = 150000.00m
                },
                new Expense
                {
                    Id = new Guid("6689ef6a-1d3b-4d76-86c2-b5b238bfb986"),
                    Name = "Rentals",
                    Price = 25000.00m
                },
                new Expense
                {
                    Id = new Guid("35220c01-515e-476a-91ca-63f3d4a5d1be"),
                    Name = "Water bills",
                    Price = 10000.00m
                },
                new Expense
                {
                    Id = new Guid("408b5103-01b7-4175-9c49-72af6b8b2409"),
                    Name = "Stationary",
                    Price = 5000.00m
                }
            };

            return expenses;
        }

       
    }
}
