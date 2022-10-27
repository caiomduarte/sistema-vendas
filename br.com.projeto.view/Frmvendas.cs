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
    public partial class Frmvendas : Form
    {

        //Objetos Cliente e ClienteDAO
        Cliente cliente = new Cliente();
        ClienteDAO cdao = new ClienteDAO();

        //Objetos de Produto
        Produto p = new Produto();
        ProdutoDAO pdao = new ProdutoDAO();

        //Variaveis
        int qtd;
        decimal preco;
        decimal subtotal, total;

        //Carrinho
        DataTable carrinho = new DataTable();


        public Frmvendas()
        {
            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tabelaProdutos.DataSource = carrinho;


        }

        private void Txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
           

                if (e.KeyChar == 13)
                {
                    cliente = cdao.retornaClientePorCpf(txtcpf.Text);

                if (cliente != null)
                {
                    txtnome.Text = cliente.nome;
                }
                else
                {
                    txtcpf.Clear();
                    txtcpf.Focus();
                }

                  
                   

                }   
            
          
        }

        private void Txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                p = pdao.retornaProdutoPorCodigo(Int64.Parse(txtcodigo.Text));

                if (p != null){
                    txtdesc.Text = p.descricao;
                    txtpreco.Text = p.preco.ToString();

                }else{
                    txtcodigo.Clear();
                    txtcodigo.Focus();
                }

            }
        }

        private void Frmvendas_Load(object sender, EventArgs e)
        {
           
            //Pegando a data atual
            txtdata.Text = DateTime.Now.ToShortDateString();





        }

        private void Btnremover_Click(object sender, EventArgs e)
        {
            //Botao remover item
            decimal subproduto = decimal.Parse(tabelaProdutos.CurrentRow.Cells[4].Value.ToString());

            int indice = tabelaProdutos.CurrentRow.Index;
            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= subproduto;

            txttotal.Text = total.ToString();

            MessageBox.Show("Item Removido do carrinho com sucesso!");
        }

        private void Btnpagamento_Click(object sender, EventArgs e)
        {
            //Botao Pagamento
            DateTime dataatual = DateTime.Parse(txtdata.Text);
            Frmpagamentos tela = new Frmpagamentos(cliente, carrinho, dataatual);

            //Passando o total para a tela de pagamentos
            tela.txttotal.Text = total.ToString();

            tela.ShowDialog();    

          
        }

        private void Txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão adicionar item
                qtd = int.Parse(txtqtd.Text);
                preco = decimal.Parse(txtpreco.Text);

                subtotal = qtd * preco;

                total += subtotal;

                //Adicionar o produto no carrinho
                carrinho.Rows.Add(int.Parse(txtcodigo.Text), txtdesc.Text, qtd, preco, subtotal);

                txttotal.Text = total.ToString();

                //Limpar os campos
                txtcodigo.Clear();
                txtdesc.Clear();
                txtqtd.Clear();
                txtpreco.Clear();

                txtcodigo.Focus();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Digite o código do Produto!");
            }


        }
    }
}
