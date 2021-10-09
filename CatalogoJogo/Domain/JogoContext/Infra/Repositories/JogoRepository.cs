using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogo.Domain.JogoContext.Entities;
using CatalogoJogo.Domain.JogoContext.Infra.Context;
using CatalogoJogo.Domain.JogoContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJogo.Domain.JogoContext.Infra
{
    public class JogoRepository : IJogoRepository
    {
        readonly JogoDataContext _context;
        public JogoRepository(JogoDataContext context)
        {
            _context = context;
        }

        public async Task Alterar(Jogo jogo)
        {
            _context.Jogos.Update(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Guid id)
        {
            var jogo = await _context.Jogos.AsNoTracking().FirstOrDefaultAsync(j => j.Id == id);

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Jogo jogo)
        {
            await _context.Jogos.AddAsync(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogo> ObterPorId(Guid id)
        {
            return await _context.Jogos.FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Jogo>> ObterTodos()
        {
            return await _context.Jogos
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}