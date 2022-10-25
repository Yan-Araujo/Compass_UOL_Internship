using Clientes.Application;
using Clientes.Data;
using Clientes.Domain;
using Microsoft.Extensions.DependencyInjection;


namespace Marketplace.Clientes.Console
{
    public class program 
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<IClientesService, ClienteService>()
                .AddScoped<IClientesRepository, ClientesRepository>()
                .BuildServiceProvider();

            var _clienteService = serviceCollection.GetService<IClientesService>();


            System.Console.WriteLine("Bem Vindo!!");
            System.Console.WriteLine("Digite 1 para Atualizar dados de um arquivo Json.");
            System.Console.WriteLine("Digite 2 para deletar dados de um arquivo Json.");
            System.Console.WriteLine("Digite 3 para exibir dados de um arquivo Json.");
            System.Console.WriteLine("Digite 0 para encerrar o programa.");
            var opcaoTeste = int.Parse(System.Console.ReadLine());
            var cont = 1;

            _clienteService.Create();

            if (opcaoTeste == 1)
            {
                    System.Console.WriteLine("Insira o Id do Cliente para a atualização: ");
                    var id = Guid.Parse(System.Console.ReadLine());
                    System.Console.WriteLine("Insira o novo nome, novo salário e nova comissão do Cliente: ");
                    var nome = System.Console.ReadLine();
                    var salario = Decimal.Parse(System.Console.ReadLine());
                    var comissao = Decimal.Parse(System.Console.ReadLine());
                    _clienteService.Up(id, nome, salario, comissao); 
            }
            else if (opcaoTeste == 2)
            {
                System.Console.WriteLine("Insira o Id do Cliente que será apagado: ");
                var id = Guid.Parse(System.Console.ReadLine());
                _clienteService.Del(id);
            }
            else if (opcaoTeste == 3)
            {
                System.Console.WriteLine("Digite 1 para Busca Seletiva ou 2 para Busca por grupos de 10 clientes");
                var opcaoTeste2 = int.Parse(System.Console.ReadLine());
                if (opcaoTeste2 == 1)
                {
                    System.Console.WriteLine("Insira o Id do Cliente que será exibido: ");
                    var id = Guid.Parse(System.Console.ReadLine());
                    _clienteService.lerId(id);
                }
                if (opcaoTeste2 == 2)
                {
                    _clienteService.LerDez();
                }
            }
            
            else if (opcaoTeste == 0)
            {
                System.Console.WriteLine("Encerrando Programa.");
            }
            
        }
        
    }

}

 