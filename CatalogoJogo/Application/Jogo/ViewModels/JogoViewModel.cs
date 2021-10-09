using System;
using System.Collections.Generic;
using CatalogoJogo.Domain.JogoContext.Entities;

namespace CatalogoJogo.Application.JogoContext.ViewModels
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Desenvolvedor { get; set; }
        public double Preco { get; set; }

        public static JogoViewModel ToMap(Jogo jogo)
        {
            if (jogo == null) return default;
            
            return new JogoViewModel
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Desenvolvedor = jogo.Desenvolvedor,
                Preco = jogo.Preco
            };
        }

        public static IEnumerable<JogoViewModel> ToMapMany(IEnumerable<Jogo> jogos)
        {
            foreach (var jogo in jogos)
            {
                yield return new JogoViewModel
                {
                    Id = jogo.Id,
                    Titulo = jogo.Titulo,
                    Desenvolvedor = jogo.Desenvolvedor,
                    Preco = jogo.Preco
                };
            }
        }
    }
}