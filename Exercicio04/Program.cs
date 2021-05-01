using Exercicio04.Entities;
using Exercicio04.Repositories;
using System;

namespace Exercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n - Cadastro de Clientes - \n");

            try
            {
                var cliente = new Cliente();

                Console.WriteLine("\nInforme o Nome do Cliente......:");
                cliente.Nome = Console.ReadLine();

                Console.WriteLine("\nInforme o CPF do Cliente......:");
                cliente.Cpf = Console.ReadLine();

                Console.WriteLine("\nData de Nascimento do Cliente......:");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nInforme o Email do Cliente......:");
                cliente.Email = Console.ReadLine();

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                Console.WriteLine("\nCliente cadastrado com sucesso!");

                Console.WriteLine("\n --- Consulta de Cliente --- \n");

                foreach (var item in clienteRepository.Consultar())
                {
                    Console.WriteLine("Id do Cliente......: " + item.IdCliente);
                    Console.WriteLine("CPF do Cliente.....: " + item.Cpf);
                    Console.WriteLine("Data de Nascimento.: " + item.DataNascimento);
                    Console.WriteLine("Email do Cliente...: " + item.Email);

                    Console.WriteLine("----");
                }
            }
            catch(Exception )
            {
                Console.WriteLine("\nErro");
            }

            Console.ReadKey();
        }
    }
}
