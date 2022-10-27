
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
    public partial class Frmpagamentos : Form
    {
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dataatual;


        public Frmpagamentos(Cliente cliente, DataTable carrinho, DateTime dataatual)
        {

            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dataatual = dataatual;

            InitializeComponent();
        }



        private void Frmpagamentos_Load(object sender, EventArgs e)
        {
            //Carrega tela
            txttroco.Text = "0,00";
            txtdinheiro.Text = "0,00";
            txtcartao.Text = "0,00";
        }

        private void Btnfinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botao finalizar Venda
                decimal v_dinheiro, v_cartao, troco, totalpago, total;
                ProdutoDAO dao_produto = new ProdutoDAO();

                int qtd_estoque, qtd_comprada, estoque_atualizado;

                v_dinheiro = decimal.Parse(txtdinheiro.Text);
                v_cartao = decimal.Parse(txtcartao.Text);
                total = decimal.Parse(txttotal.Text);

                //Calcular o total pago
                totalpago = v_dinheiro + v_cartao;

                if(totalpago < total)
                {
                    MessageBox.Show("O total pago é menor que o valor Total da Venda!");
                }
                else {

                    //Calcular o troco
                    troco = totalpago - total;

                    Venda vendas = new Venda();

                    //Pegando o id do cliente
                    vendas.cliente_id = cliente.codigo;
                    vendas.data_venda = dataatual;
                    vendas.total_venda = total;
                    vendas.obs = txtobs.Text;

                    VendaDAO vdao = new VendaDAO();
                    txttroco.Text = troco.ToString();

                    vdao.cadastrarVenda(vendas);

                    //Cadastrar os itens da venda
                    //Percorrendo os itens do carrinho
                    foreach (DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda();
                        item.venda_id   = vdao.retornaIdUltimaVenda();
                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd        = int.Parse(linha["Qtd"].ToString());
                        item.subtotal   = decimal.Parse(linha["Subtotal"].ToString());


                        //Baixa no estoque
                        qtd_estoque = dao_produto.retornaEstoqueAtual(item.produto_id);
                        qtd_comprada = item.qtd;
                        estoque_atualizado = qtd_estoque - qtd_comprada;

                        dao_produto.baixaEstoque(item.produto_id, estoque_atualizado);


                        ItemVendaDAO itemdao = new ItemVendaDAO();
                        itemdao.cadastrarItem(item);

                    }

                    MessageBox.Show("Venda Finalizada com Sucesso!");



                   
                    // this.Dispose();

                    for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
                    {
                        if (Application.OpenForms[intIndex] != this)
                            Application.OpenForms[intIndex].Close();
                    }


                     new Frmvendas().ShowDialog();

                }




            }
            catch (Exception)
            {

                throw;
            }

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("CUPOM", 285, 600);

            printPreviewDialog1.ShowDialog();
        }
    }
}
