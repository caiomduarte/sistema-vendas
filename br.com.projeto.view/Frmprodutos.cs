using Projeto_Controle_Vendas.br.com.projeto.dao;
using Projeto_Controle_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.view
{
    public partial class Frmprodutos : Form
    {
        public Frmprodutos()
        {
            InitializeComponent();
        }

        private void Frmprodutos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();
            cbfornecedor.DataSource = f_dao.listarFornecedores();
            cbfornecedor.DisplayMember =  "nome";
            cbfornecedor.ValueMember = "id";

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProdutos.DataSource = dao.listarProdutos();          



        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor do combobox: " + cbfornecedor.SelectedValue);
        }

        private void Btnsalvar_Click(object sender, EventArgs e)
        {
            //1 Passo é receber todos os dados da tela 
            Produto obj = new Produto();

            obj.descricao = txtdesc.Text;
            obj.preco = decimal.Parse(txtpreco.Text);
            obj.qtdestoque = int.Parse(txtqtd.Text);
            obj.for_id = int.Parse(cbfornecedor.SelectedValue.ToString());

            //2 passo - Criar o objeto Dao
            ProdutoDAO dao = new ProdutoDAO();
            dao.cadastraProduto(obj);

            new Helpers().LimparTela(this);

            //Recarregar o meu datagridView
            tabelaProdutos.DataSource = dao.listarProdutos();


        }

        private void Btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void TabelaProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os dados de um produto selecionado
            txtcodigo.Text = tabelaProdutos.CurrentRow.Cells[0].Value.ToString();
            txtdesc.Text   = tabelaProdutos.CurrentRow.Cells[1].Value.ToString();
            txtpreco.Text  = tabelaProdutos.CurrentRow.Cells[2].Value.ToString();
            txtqtd.Text    = tabelaProdutos.CurrentRow.Cells[3].Value.ToString();

            cbfornecedor.Text =  tabelaProdutos.CurrentRow.Cells[4].Value.ToString();
            
            //Alterar para a guia Dados Pessoais
            tabProdutos.SelectedTab = tabPage1;
        }

        private void Btneditar_Click(object sender, EventArgs e)
        {
            //Botão Editar Produto
            //1 Passo é receber todos os dados da tela 
            Produto obj = new Produto();

            obj.descricao = txtdesc.Text;
            obj.preco = decimal.Parse(txtpreco.Text);
            obj.qtdestoque = int.Parse(txtqtd.Text);
            obj.for_id = int.Parse(cbfornecedor.SelectedValue.ToString());
            obj.id = int.Parse(txtcodigo.Text);

            //2 passo - Criar o objeto Dao
            ProdutoDAO dao = new ProdutoDAO();
            dao.alterarProduto(obj);

            new Helpers().LimparTela(this);

            //Recarregar o meu datagridView
            tabelaProdutos.DataSource = dao.listarProdutos();

        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            //Botão Editar Produto
            //1 Passo é receber todos os dados da tela 
            Produto obj = new Produto();

             obj.id = int.Parse(txtcodigo.Text);

            //2 passo - Criar o objeto Dao
            ProdutoDAO dao = new ProdutoDAO();
            dao.excluirProduto(obj);

            new Helpers().LimparTela(this);

            //Recarregar o meu datagridView
            tabelaProdutos.DataSource = dao.listarProdutos();
        }

        private void Txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.listarProdutosPorNome(nome);


        }

        private void Btnpesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtpesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.BuscarProdutosPorNome(nome);

            if(tabelaProdutos.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Produto encontrado com esse Nome");
                //Recarregar o datagridview
                tabelaProdutos.DataSource = dao.listarProdutos();

            }
        }
    }
}
