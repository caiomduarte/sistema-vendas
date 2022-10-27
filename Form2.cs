using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Conexão com o banco de dados
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;
            MySqlConnection con = new MySqlConnection(conexao);

            string sql = "SELECT * FROM TB_FORNECEDORES";
            MySqlCommand comando = new MySqlCommand(sql, con);
            
            con.Open();
            comando.ExecuteNonQuery();

            DataTable tabelaFornecedores = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(tabelaFornecedores);

            dataGridView1.DataSource = tabelaFornecedores;

            cbfornecedor.DataSource    = tabelaFornecedores;
            cbfornecedor.DisplayMember = "nome";
            cbfornecedor.ValueMember   = "id";

        }
    }
}
