using System;
using System.Text;
using Dio.AppSeries.Domain.Core;
using Dio.AppSeries.Domain.Enum;

namespace Dio.AppSeries.Domain
{
    public class Serie : Entidade
    {
		public Genero Genero { get; private set; }
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public int Ano { get; private set; }
        public bool Excluido {get; private set;}

		public Serie(int id, Genero genero, string titulo, string descricao, int ano)
		{
			Id = id;
			Genero = genero;
			Titulo = titulo;
			Descricao = descricao;
			Ano = ano;
            Excluido = false;
		}

        public override string ToString()
		{
			StringBuilder entidade = new();
			entidade.Append("Gênero: " + Genero).AppendLine();
			entidade.Append("Titulo: " + Titulo).AppendLine();
			entidade.Append("Descrição: " + Descricao).AppendLine();
			entidade.Append("Ano de Início: " + Ano).AppendLine();
            entidade.Append("Excluido: " + Excluido).AppendLine();
			
			return entidade.ToString();
		}

        public void Excluir() {
            Excluido = true;
        }
    }
}