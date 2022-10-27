
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;


namespace Projeto_Controle_Vendas.br.com.projeto.conexao
{
    public class ConnectionFactory
    {
        //metodo que conecta o banco de dados

        public  MySqlConnection getconnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

            return new MySqlConnection(conexao);
        }


    }
}
