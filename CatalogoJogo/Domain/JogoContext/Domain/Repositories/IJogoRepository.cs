using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogo.Domain.JogoContext.Entities;

namespace CatalogoJogo.Domain.JogoContext.Repositories
{
    public interface IJogoRepository
    {
        Task Inserir(Jogo jogo);
        Task<IEnumerable<Jogo>> ObterTodos();
        Task<Jogo> ObterPorId(Guid id);
        Task Alterar(Jogo jogo);
        Task Excluir(Guid id);
    }
}