using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogo.Application.JogoContext.Models;
using CatalogoJogo.Application.JogoContext.ViewModels;
using CatalogoJogo.Domain.Core;
using CatalogoJogo.Domain.JogoContext.Entities;
using CatalogoJogo.Domain.JogoContext.Repositories;

namespace CatalogoJogo.Application.JogoContext.Services
{
    public class JogoService : IJogoService
    {
        readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public async Task Alterar(Guid id, JogoInputModel jogo)
        {
            var jogoDb = await _repository.ObterPorId(id);

            if (jogoDb == null) throw new DomainCoreException("Jogo não encontrado");

            jogoDb.AlterarTitulo(jogo.Titulo);
            jogoDb.AlterarDesenvolvedor(jogo.Desenvolvedor);
            jogoDb.AlterarPreco(jogo.Preco);

            await _repository.Alterar(jogoDb);
        }

        public async Task Excluir(Guid id)
        {
            await _repository.Excluir(id);
        }

        public async Task Inserir(JogoInputModel jogo)
        {
            await _repository.Inserir(new Jogo(
                jogo.Titulo,
                jogo.Desenvolvedor,
                jogo.Preco
            ));
        }

        public async Task<JogoViewModel> ObterPorId(Guid id)
        {
            var jogo = await _repository.ObterPorId(id);

            return JogoViewModel.ToMap(jogo);
        }

        public async Task<IEnumerable<JogoViewModel>> ObterTodos()
        {
            return JogoViewModel.ToMapMany(
                await _repository.ObterTodos()
            );
        }
    }
}