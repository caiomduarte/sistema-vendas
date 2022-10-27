using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.br.com.projeto.conexao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                new ConnectionFactory().getconnection();
                MessageBox.Show("Conectado");
            }
            catch (Exception erro)
            {

                MessageBox.Show("erro " + erro);
            }
        
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexao = new ConnectionFactory().getconnection();
                conexao.Open();
                MessageBox.Show("Conectado com sucesso!");
            }
            catch (MySqlException erro)
            {
                 MessageBox.Show("Desconectado! Erro: " + erro);
            }
        }
    }
}
