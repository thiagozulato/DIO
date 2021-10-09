using CatalogoJogo.Domain.Core;

namespace CatalogoJogo.Domain.JogoContext.Entities
{
    public class Jogo : Entity
    {
        public Jogo(string titulo, string desenvolvedor, double preco)
        {
            Titulo = titulo;
            Desenvolvedor = desenvolvedor;
            Preco = preco;
        }

        public string Titulo { get; private set; }
        public string Desenvolvedor { get; private set; }
        public double Preco { get; private set; }

        public void AlterarTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public void AlterarDesenvolvedor(string desenvolvedor)
        {
            Desenvolvedor = desenvolvedor;
        }

        public void AlterarPreco(double preco)
        {
            Preco = preco;
        }
    }
}