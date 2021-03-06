using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spending.Domain.Interfaces.IServices
{
    public interface IFilterService
    {
        Task<List<FilterEntity>> GetYearsAsync();
        Task<List<FilterEntity>> GetProductsAsync();
        Task<List<FilterEntity>> GetMonthsByYearAsync(int year);
    }
}
