using Microsoft.AspNetCore.Mvc;
using Spending.Api.Controllers.Base;
using Spending.Domain;
using Spending.Domain.Interfaces.IServices;
using System;
using System.Threading.Tasks;

namespace Spending.Api.Controllers
{
    [Route("produto")]
    public class ProductController : BaseAuthController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert([FromBody] ProductEntity product)
        {
            var insert = await _productService.InsertAsync(product);

            if (insert)
                return Ok(new { message = "Produto salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar produto." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update([FromBody] ProductEntity product)
        {
            var update = await _productService.UpdateAsync(product);

            if (update)
                return Ok(new { message = "Produto atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar produto." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromHeader] ProductEntity product)
        {
            var delete = await _productService.DeleteAsync(product);

            if (delete)
                return Ok(new { message = "Produto deletado com sucesso." });

            return BadRequest(new { message = "Erro ao deletar produto." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var products = await _productService.GetAllAsync();

            if (products != null)
                return Ok(products);

            return NotFound("Produtos não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product != null)
                return Ok(product);

            return NotFound("Produto não encontrado");
        }
    }
}