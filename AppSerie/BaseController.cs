using System;

namespace Dio.AppSeries
{
    public abstract class BaseController
    {
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