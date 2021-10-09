using System;
using System.Collections.Generic;
using Dio.AppSeries.Domain.Repositorios;

namespace Dio.AppSeries.Domain.Infra
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private readonly static List<Serie> listaSerie = new();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}