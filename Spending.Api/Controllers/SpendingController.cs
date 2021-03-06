using Microsoft.AspNetCore.Mvc;
using Spending.Api.Controllers.Base;
using Spending.Domain;
using Spending.Domain.Interfaces.IServices;
using System;
using System.Threading.Tasks;

namespace Spending.Api.Controllers
{
    [Route("gastos")]
    public class SpendingController : BaseAuthController
    {
        private readonly ISpendingService _spendingService;

        public SpendingController(ISpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Save([FromBody] SpendingEntity spending)
        {
            var insert = await _spendingService.InsertAsync(spending);

            if (insert)
                return Ok(new { message = "Gasto salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar gasto." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update([FromBody] SpendingEntity spending)
        {
            var update = await _spendingService.UpdateAsync(spending);

            if (update)
                return Ok(new { message = "Gasto atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar gasto." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromHeader] SpendingEntity spending)
        {
            var delete = await _spendingService.DeleteAsync(spending);

            if (delete)
                return Ok(new { message = "Gasto deletado com sucesso." });

            return BadRequest(new { message = "Erro ao deletar gasto." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var spendings = await _spendingService.GetAllAsync();

            if (spendings != null)
                return Ok(spendings);

            return NotFound("Gastos não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var spending = await _spendingService.GetByIdAsync(id);

            if (spending != null)
                return Ok(spending);

            return NotFound("Gasto não encontrado");
        }
    }
}