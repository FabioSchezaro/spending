using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spending.Domain;
using Spending.Domain.Interfaces.IRepositories;
using Spending.Domain.Interfaces.IServices;
using Spending.Domain.Interfaces.IUnitOfWork;

namespace Spending.Service
{
    public class FilterService : IFilterService
    {
        private readonly ISpendingRepository _spendingRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FilterService(ISpendingRepository spendingRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _spendingRepository = spendingRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FilterEntity>> GetYearsAsync()
        {
            var spendingsYears = await _spendingRepository.GetYearsAsync(_unitOfWork.GetConnection());
            List<FilterEntity> years = new List<FilterEntity>();

            foreach (var spendingYear in spendingsYears)
            {
                FilterEntity filter = new FilterEntity();

                SetFilterObject(filter, spendingYear.Year.ToString(), spendingYear.Year.ToString(), spendingYear.TotalValue.ToString());

                years.Add(filter);
            }

            return years;
        }

        public async Task<List<FilterEntity>> GetProductsAsync()
        {
            var productsCollection = await _spendingRepository.GetSpendingProductsAsync(_unitOfWork.GetConnection());
            List<FilterEntity> products = new List<FilterEntity>();

            foreach (var product in productsCollection)
            {
                var detailsByProducts = productsCollection.FindAll(x => x.Id == product.Id);
                FilterEntity filter = new FilterEntity();

                foreach (var p in detailsByProducts)
                {
                    DetailEntity detail = SetDetailObject(p);
                    filter.DetailCollection.Add(detail);
                }

                if (products.Find(x => x.Id == product.Id.ToString()) == null)
                {
                    SetFilterObject(filter, product.Id.ToString(), product.ProductDescription, product.TotalValue.ToString());
                    products.Add(filter);
                }
                //FilterEntity filter = new FilterEntity();

                //SetFilterObject(filter, product.Id.ToString(), product.Description, product.Price.ToString());

                //products.Add(filter);
            }

            return products;
        }

        public async Task<List<FilterEntity>> GetMonthsByYearAsync(int year)
        {
            var spendings = await _spendingRepository.GetMonthsByYearAsync(_unitOfWork.GetConnection(), year);
            List<FilterEntity> months = new List<FilterEntity>();

            foreach (var spending in spendings)
            {
                var detailsByMonth = spendings.FindAll(x => x.Month == spending.Month && x.ProductId == spending.ProductId);
                FilterEntity filter = new FilterEntity();

                foreach (var d in detailsByMonth)
                {
                    DetailEntity detail = SetDetailObject(d);
                    filter.DetailCollection.Add(detail);
                }

                if (months.Find(x => x.Id == spending.Month.ToString()) == null)
                {
                    SetFilterObject(filter, spending.Month.ToString(), spending.MonthDescription, spending.TotalValue.ToString());
                    months.Add(filter);
                }
            }

            return months;
        }

        private DetailEntity SetDetailObject(SpendingEntity spending)
        {
            return new DetailEntity
            {
                ProductDescription = spending.ProductDescription,
                CurrentParcel = spending.CurrentParcel,
                Month = spending.Month,
                RemaingParcel = spending.RemaingParcel,
                ParcelValue = spending.ParcelValue,
                ProductId = spending.ProductId,
                Year = spending.Year
            };
        }

        private static void SetFilterObject(FilterEntity filter, string id, string description, string totalValue)
        {
            filter.Id = id;
            filter.Description = description;
            filter.TotalValue = totalValue;
        }
    }
}
