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
        private const int INSURANCE_CATEGORY = 12;
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

        public double GetActualBillByCategory(int categoryId, int? year = null, int? month = null)
        {
            var payed = GetPayeds();

            if (year == null || month == null)
            {
                var now = DateTime.Now;
                year = now.Year;
                month = now.Month;
            } 

            var sum = payed
                .Where(x => x.Date.Year == year && x.Date.Month == month && x.CategoryId == categoryId)
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

        public RequiredBillPrice? GetLatestPriceByCategoryAndDate(int categoryId, int year, int month)
        {
            var prices = GetPrices();

            var latestPrice = prices
                .Where(x => x.CategoryId == categoryId)
                .Where(y => y.Date.Year <= year && y.Date.Month <= month)
                .OrderByDescending(y => y.Date)
                .FirstOrDefault();

            return latestPrice;
        }

        public IEnumerable<RequiredBillCategory> GetActiveCategories()
        {
            var categories = GetCategories().Where(x => !x.IsArchive);
            var specificCategories = SpecialLogic(categories);
            return specificCategories;
        }

        private IEnumerable<RequiredBillCategory> SpecialLogic(IEnumerable<RequiredBillCategory> categories)
        {
            var acceptedMonths = new List<int> { 1, 4, 7, 10 };
            var nowMonth = DateTime.Now.Month;
            var categoriesList = categories.ToList();

            if (acceptedMonths.All(x => x != nowMonth))
            {
                var toRemove = categoriesList.FirstOrDefault(x => x.Id == INSURANCE_CATEGORY);
                categoriesList.Remove(toRemove);
            }

            return categoriesList;
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
                    IsCompleted = actualBill >= requiredBill,
                    Type = category.Type
                };

                bills.Add(bill);
            }

            return bills;
        }

        public IEnumerable<CurrentBillDto> GetBillsBy(DateBillDto dto)
        {
            var now = DateTime.Now;
            IEnumerable<CurrentBillDto> bills = new List<CurrentBillDto>();

            if (dto.Year == now.Year && dto.Month == now.Month)
            {
                bills = GetCurrentBills();
            }
            else
            {
                bills = GetSelectedBills(dto);
            }

            bills = bills.Where(x => x.Type == dto.Type);

            return bills;
        }

        public IEnumerable<CurrentBillDto> GetSelectedBills(DateBillDto dto)
        {
            var bills = new List<CurrentBillDto>();
            var categories = GetCategories();

            foreach (var category in categories)
            {
                var requiredBill = GetLatestPriceByCategoryAndDate(category.Id, dto.Year, dto.Month)?.Value ?? 0.0;
                var actualBill = GetActualBillByCategory(category.Id, dto.Year, dto.Month);

                var bill = new CurrentBillDto
                {
                    Category = category.Name,
                    RequiredBill = requiredBill,
                    ActualBill = actualBill,
                    IsCompleted = actualBill >= requiredBill,
                    Type = category.Type
                };

                bills.Add(bill);
            }

            return bills;
        }

        public IEnumerable<CurrentBillDto> GetCurrentBillsByType(BillTypeDefinition type)
        {
            var response = GetCurrentBills();
            return response.Where(x => x.Type == type);
        }

        public CurrentBillDto GetCurrentBillsTotal(BillTypeDefinition type)
        {
            var currentBills = GetCurrentBillsByType(type).ToList();

            return new CurrentBillDto()
            {
                Category = "Total",
                ActualBill = currentBills.Sum(x => x.ActualBill),
                RequiredBill = currentBills.Sum(x => x.RequiredBill),
                IsCompleted = currentBills.All(x => x.IsCompleted)
            };
        }

        public RequiredBillPayed Add(RequiredBillPayed payed) => SafeInsert(payed);
    }
}
