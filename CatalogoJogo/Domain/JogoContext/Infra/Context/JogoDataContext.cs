using CatalogoJogo.Domain.JogoContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJogo.Domain.JogoContext.Infra.Context
{
    public class JogoDataContext : DbContext
    {
        public JogoDataContext(DbContextOptions<JogoDataContext> options) : base(options) { }

        public DbSet<Jogo> Jogos { get; set; }        
    }
}