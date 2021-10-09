using System;

namespace Dio.AppSeries
{
    public abstract class BaseController
    {
        /// <summary>
        /// Executa uma operação e faz o tratamento de erro.
        /// </summary>
        /// <param name="nomeOperacao">Nome da operação a ser executada</param>
        /// <param name="operacao">Método a ser executado.</param>
        public void Executar(string nomeOperacao, Action operacao)
        {
            try
            {
                operacao();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ({nomeOperacao}) -> [{ex.Message}]"); 
            }
        }
    }
}