using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogo.Application.JogoContext.Models;
using CatalogoJogo.Application.JogoContext.ViewModels;

namespace CatalogoJogo.Application.JogoContext.Services
{
    public interface IJogoService
    {
        Task Inserir(JogoInputModel jogo);
        Task<IEnumerable<JogoViewModel>> ObterTodos();
        Task<JogoViewModel> ObterPorId(Guid id);
        Task Alterar(Guid id, JogoInputModel jogo);
        Task Excluir(Guid id);
    }
}