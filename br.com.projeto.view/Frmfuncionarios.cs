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
    public partial class Frmfuncionarios : Form
    {
        public Frmfuncionarios()
        {
            InitializeComponent();
        }

        private void Btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void Btnsalvar_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Funcionario obj = new Funcionario();


            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text.Replace(",", ".");
            obj.cpf = txtcpf.Text.Replace(",", ".");
            obj.senha = txtsenha.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;
            obj.nivel_acesso = cbnivel.Text;
            obj.cargo = cbcargo.Text;

            obj.codigo = int.Parse(txtcodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastraCliente
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.alterarFuncionario(obj);

            //recarregar o datagridview
            tabelaFuncionarios.DataSource = dao.listarFuncionarios();
        }

        private void Btneditar_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Funcionario obj = new Funcionario();


            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text.Replace(",", ".");
            obj.cpf = txtcpf.Text.Replace(",", ".");
            obj.senha = txtsenha.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;
            obj.nivel_acesso = cbnivel.Text;
            obj.cargo = cbcargo.Text;

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastraCliente
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(obj);

            //recarregar o datagridview
            tabelaFuncionarios.DataSource = dao.listarFuncionarios();
        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Funcionario obj = new Funcionario();


            obj.codigo = int.Parse(txtcodigo.Text);
           

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastraCliente
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.deletarFuncionario(obj);

            //recarregar o datagridview
            tabelaFuncionarios.DataSource = dao.listarFuncionarios();
        }

        private void Frmfuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            //recarregar o datagridview
            tabelaFuncionarios.DataSource = dao.listarFuncionarios();

        }

        private void Btnpesquisar_Click(object sender, EventArgs e)
        {
            //Botao pesquisar
            string nome = txtpesquisa.Text;
            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionarios.DataSource = dao.BuscaFuncionariosPorNome(nome);

            if (tabelaFuncionarios.Rows.Count == 0)
            {
                //Recarregar o datagridview
                tabelaFuncionarios.DataSource = dao.listarFuncionarios();
            }
        }

        private void TabelaFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtcodigo.Text = tabelaFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = tabelaFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbcargo.Text = tabelaFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbnivel.Text = tabelaFuncionarios.CurrentRow.Cells[7].Value.ToString();

            txttelefone.Text = tabelaFuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = tabelaFuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = tabelaFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = tabelaFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = tabelaFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtcomp.Text = tabelaFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = tabelaFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = tabelaFuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbuf.Text = tabelaFuncionarios.CurrentRow.Cells[16].Value.ToString();

            //Alterar para a guia Dados Pessoais
            tabFuncionario.SelectedTab = tabPage1;
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            //Botao consultar Cep
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomp.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Endereço não encontrado, por favor digite manualmente.");
            }
        }

        private void Txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionarios.DataSource = dao.listarFuncionariosPorNome(nome);
        }
    }
}
