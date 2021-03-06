using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spending.Api.Controllers.Base;
using Spending.Domain;
using Spending.Domain.Interfaces.IServices;
using Spending.Token.Service;

namespace Spending.Api.Controllers
{
    [Route("usuario")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("autenticacao")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromHeader] UserEntity entity)
        {
            var user = await _userService.AuthenticateAsync(entity);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return Ok(new { user, Token = token });
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert([FromBody] UserEntity entity)
        {
            var inserted = await _userService.InsertAsync(entity);

            if (inserted)
               return Ok(new { message = "Usuário inserido com sucesso" });
            
            return BadRequest(new { message = "Erro ao salvar usuário" });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update([FromBody] UserEntity entity)
        {
            var updated = await _userService.UpdateAsync(entity);

            if (updated)
                return Ok(new { message = "Usuário atualizado com sucesso" });

            return BadRequest(new { message = "Erro ao atualizar usuário" });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromHeader] UserEntity entity)
        {
            var deleted = await _userService.DeleteAsync(entity);

            if (deleted)
                return Ok(new { message = "Usuário removido com sucesso" });

            return BadRequest(new { message = "Erro ao remover usuário" });

        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var users = await _userService.GetAllAsync();

            if (users != null)
                return Ok(users.OrderBy(x => x.Name));

            return BadRequest(new { message = "Não há usuários para mostrar" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var users = await _userService.GetByIdAsync(id);

            if (users != null)
                return Ok(users);

            return BadRequest(new { message = "Não há usuários para mostrar" });
        }
    }
}