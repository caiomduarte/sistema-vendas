


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
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Frmclientes_Load(object sender, EventArgs e)
        {

            tabelaCliente.DefaultCellStyle.ForeColor = Color.Black;
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
       
        
        private void Btnsalvar_Click(object sender, EventArgs e)
        {

            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();
              
            
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text.Replace(",", ".");
            obj.cpf = txtcpf.Text.Replace(",", ".");
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

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastraCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            //recarregar o datagridview
            tabelaCliente.DataSource = dao.listarClientes();


        }

        private void Txtcep_Leave(object sender, EventArgs e)
        {
            
        }

        private void Txtcep_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void Txtcep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    cepConsulta address = correiosCEP.GetAddress(txtcep.Text);

            //    txtendereco.Text = address.Rua;     // Avenida Euclides da Cunha
            //    txtbairro.Text = address.Bairro;  // Jardim São Jorge
            //    txtcidade.Text = address.Cidade;      // Paranavaí
            //                                          //

            //    cbuf.Text = address.UF;     // PR
            //    txtcep.Text = address.Cep;       // 87710130
            //}
            //catch (Exception erro)
            //{

            //    MessageBox.Show("erro" + erro);
            //}
        }

        private void TabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Pegar os dados da linha selecionada
            txtcodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a guia Dados Pessoais
            tabClientes.SelectedTab = tabPage1;

        }

        private void Btneditar_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente
            Cliente obj = new Cliente();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
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

            obj.codigo = int.Parse(txtcodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo alterar
            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            //recarregar o datagridview
            tabelaCliente.DataSource = dao.listarClientes();

        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Cliente obj = new Cliente();

            //pegar o codigo 
            obj.codigo = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.excluirCliente(obj);

            //Recarregar o datagridview
            tabelaCliente.DataSource = dao.listarClientes();
            


        }

        private void Btnpesquisar_Click(object sender, EventArgs e)
        {
            //Botao pesquisar
            string nome = txtpesquisa.Text;
            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.BuscarClientePorNome(nome);

            if(tabelaCliente.Rows.Count == 0)
            {
                //Recarregar o datagridview
                tabelaCliente.DataSource = dao.listarClientes();
            }


        }

        private void Txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            //Botao consultar Cep
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";

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

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
