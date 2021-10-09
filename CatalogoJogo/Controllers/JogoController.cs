using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoJogo.Application.JogoContext.Models;
using CatalogoJogo.Application.JogoContext.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatalogoJogo.Controllers
{
    [ApiController]
    [Route("api/v1/jogos")]
    public class JogoController : ControllerBase
    {
        readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _jogoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _jogoService.ObterPorId(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> Inserir(JogoInputModel request)
        {
            await _jogoService.Inserir(request);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, JogoInputModel request)
        {
            await _jogoService.Alterar(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _jogoService.Excluir(id);

            return NoContent();
        }
    }
}
