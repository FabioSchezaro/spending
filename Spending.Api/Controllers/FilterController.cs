using Microsoft.AspNetCore.Mvc;
using Spending.Api.Controllers.Base;
using Spending.Domain.Interfaces.IServices;
using System.Threading.Tasks;

namespace Spending.Api.Controllers
{
    [Route("filter")]
    public class FilterController : BaseAuthController
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("years")]
        public async Task<ActionResult<dynamic>> GetYears()
        {
            var yearsFilter = await _filterService.GetYearsAsync();

            if (yearsFilter != null)
                return Ok(yearsFilter);

            return NotFound("Não há registros para mostrar");
        }

        [HttpGet("products")]
        public async Task<ActionResult<dynamic>> GetProducts()
        {
            var yearsFilter = await _filterService.GetProductsAsync();

            if (yearsFilter != null)
                return Ok(yearsFilter);

            return NotFound("Não há registros para mostrar");
        }

        [HttpGet("monthsbyyear/{year}")]
        public async Task<ActionResult<dynamic>> GetMonthsByYear(int year)
        {
            var yearsFilter = await _filterService.GetMonthsByYearAsync(year);

            if (yearsFilter != null)
                return Ok(yearsFilter);

            return NotFound("Não há registros para mostrar");
        }
    }
}