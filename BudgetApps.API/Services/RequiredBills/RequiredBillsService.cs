using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.DTOs.RequiredBills;
using BudgetApps.API.Entities.FluxArea;
using BudgetApps.API.Entities.RefluxArea;
using BudgetApps.API.Entities.RequiredBills;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.RequiredBills
{
    public class RequiredBillsService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;

        public RequiredBillsService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }

        public IEnumerable<RequiredBillPrice> GetPrices()
        {
            return GetAll<RequiredBillPrice>();
        }

        public IEnumerable<RequiredBillCategory> GetCategories()
        {
            return GetAll<RequiredBillCategory>();
        }

        public IEnumerable<RequiredBillPayed> GetPayeds()
        {
            return GetAll<RequiredBillPayed>();
        }

        public double GetActualBillByCategory(int categoryId)
        {
            var payed = GetPayeds();
            var now = DateTime.Now;

            var sum = payed
                .Where(x => x.Date.Year == now.Year && x.Date.Month == now.Month && x.CategoryId == categoryId)
                .Sum(x => x.Value);

            return sum;
        }

        public RequiredBillPrice? GetLatestPriceByCategory(int categoryId)
        {
            var prices = GetPrices();

            var latestPrice = prices
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(y => y.Date)
                .FirstOrDefault();

            return latestPrice;
        }

        public IEnumerable<RequiredBillCategory> GetActiveCategories()
        {
            var categories = GetCategories();

            return categories.Where(x => !x.IsArchive);
        }

        public IEnumerable<CurrentBillDto> GetCurrentBills()
        {
            var bills = new List<CurrentBillDto>();
            var activeCategories = GetActiveCategories();

            foreach (var category in activeCategories)
            {
                var requiredBill = GetLatestPriceByCategory(category.Id)?.Value ?? 0.0;
                var actualBill = GetActualBillByCategory(category.Id);

                var bill = new CurrentBillDto
                {
                    Category = category.Name,
                    RequiredBill = requiredBill,
                    ActualBill = actualBill,
                    IsCompleted = actualBill >= requiredBill
                };

                bills.Add(bill);
            }

            return bills;
        }

        public RequiredBillPayed Add(RequiredBillPayed payed) => SafeInsert(payed);
    }
}
