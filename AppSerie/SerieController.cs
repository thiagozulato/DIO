using System;
using Dio.AppSeries.Domain;
using Dio.AppSeries.Domain.Enum;
using Dio.AppSeries.Domain.Repositorios;

namespace Dio.AppSeries
{
    public sealed class SerieController : BaseController
    {
        readonly IRepositorio<Serie> _repositorio;
        public SerieController(IRepositorio<Serie> repositorio)
        {
            _repositorio = repositorio;
        }

        public void InserirSerie()
        {
            Executar(nameof(InserirSerie), () =>
            {
                Console.WriteLine("Inserir nova série");

                ImprimirGeneros();

                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new(id: _repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

                _repositorio.Insere(novaSerie);
            });
        }

        public void ListarSeries()
        {
            Executar(nameof(ListarSeries), () =>
            {
                Console.WriteLine("Listar séries");

                var lista = _repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach (var serie in lista)
                {
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.Id, serie.Titulo, serie.Excluido ? "*Excluído*" : "");
                }
            });
        }

        public void AtualizarSerie()
        {
            Executar(nameof(AtualizarSerie), () =>
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                ImprimirGeneros();

                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

                _repositorio.Atualiza(indiceSerie, atualizaSerie);
            });
        }

        public void VisualizarSerie()
        {
            Executar(nameof(VisualizarSerie), () =>
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = _repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);
            });
        }

        public void ExcluirSerie()
        {
            Executar(nameof(ExcluirSerie), () =>
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                _repositorio.Exclui(indiceSerie);
            });
        }

        private void ImprimirGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
        }
    }
}