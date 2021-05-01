using Dapper;
using Exercicio04.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Exercicio04.Repositories
{
    public class ClienteRepository
    {

        private string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDExercicio04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Inserir(Cliente cliente)
        {
            var sql = @"
                    Insert Into CLIENTE(IdCliente, Nome, Cpf, DataNascimento, Email)
                    Values(NewId(), @Nome, @Cpf, @DataNascimento, @Email)
                
                ";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);
            }
        }  
        
        public void Atualizar(Cliente cliente)
        {
            var sql = @"Update Cliente set Nome = @Nome, 
                        Cpf = @Cpf, DataNascimento = @ DataNascimento, 
                        Email = @Email
                ";
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);
            }
        }

        public void Excluir(Cliente cliente)
        {
            var sql = @"Delete From Cliente
                      Where IdCliente = IdCliente
                ";
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, cliente);
            }
        }


        public List<Cliente> Consultar()
        {
            var sql = @"select * from Cliente
                      order by Nome
                ";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Cliente>(sql).ToList();
            }
        }
    }
}
