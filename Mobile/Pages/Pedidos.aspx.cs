using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Controller;
using myWaiter.Mobile.Model;
using System.Web.UI.HtmlControls;

namespace myWaiter.Mobile.Pages
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill_Page();
        }

        public void Fill_Page()
        {
            List<ModelPedido> lmp = ControllerComandaProduto.getModelPedido();

            foreach (ModelPedido modelPedido in lmp)
            {
                //
                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tablePedido");

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td1 = new HtmlTableCell();
                td1.Attributes.Add("class", "nomeUserTeste");
                td1.ColSpan = 2;
                td1.InnerText = modelPedido.nome_Pessoa;//Deve inserir o nome do usuário, pegar pelo inner join

                HtmlTableCell tdX = new HtmlTableCell();
                tdX.Attributes.Add("class", "nomeUserTeste");
                tdX.Width = "50px";

                ImageButton ib = new ImageButton();
                ib.ImageUrl = "~/Mobile/images/paginaPedidos/btnExcluirPequeno.fw.png";
                ib.Click += btnExcluir_Click;
                ib.CommandArgument = modelPedido.idComandaProduto.ToString(); //coloco como argumento o ID do Produto_Comanda

                tdX.Controls.Add(ib);

                tr.Cells.Add(td1);
                tr.Cells.Add(tdX);
                //


                //
                HtmlImage img = new HtmlImage();
                img.Attributes.Add("class", "imagemProduto");
                img.Src = modelPedido.imagem; //Imagem do Produto, pegar pelo inner join

                HtmlTableRow tr2 = new HtmlTableRow();
                HtmlTableCell td2 = new HtmlTableCell();
                td2.RowSpan = 3;
                td2.Attributes.Add("class", "auto-style2");
                td2.Controls.Add(img);

                HtmlTableCell td3 = new HtmlTableCell();
                td2.Attributes.Add("class", "auto-style3");
                td3.ColSpan = 2;
                td3.InnerText = modelPedido.nome_Produto; //Nome do Produto, pegar pelo inner join

                tr2.Cells.Add(td2);
                tr2.Cells.Add(td3);
                //


                //
                HtmlTableRow tr3 = new HtmlTableRow();
                HtmlTableCell td4 = new HtmlTableCell();
                td4.Attributes.Add("class", "auto-style3");
                td4.InnerText = "Qtde: " + modelPedido.qtdeItemComanda.ToString(); //Quantidade de itens na Comanda_Produto
                td4.ColSpan = 2;
                tr3.Cells.Add(td4);
                //

                //
                HtmlTableRow tr4 = new HtmlTableRow();
                HtmlTableCell td5 = new HtmlTableCell();
                td5.Attributes.Add("class", "auto-style3");
                td5.InnerText = "R$ " + modelPedido.valorComandaProduto.ToString("F"); //Preço do produto (Qtde * Preço - pegar BD)
                tr4.Cells.Add(td5);
                //

                table.Rows.Add(tr);
                table.Rows.Add(tr2);
                table.Rows.Add(tr3);
                table.Rows.Add(tr4);

                lblTexto.Controls.Add(table);  
            }

            //-------------------------------Parte dos Nomes da Barra
            List<ModelPedido> lpc = ControllerComandaProduto.getNomePrecoComanda();

            foreach (ModelPedido modelPedido in lpc)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.InnerText = modelPedido.nome_Pessoa + " - R$ " + modelPedido.somaProdutoNoPedido.ToString("F");
                ulNomesPedidos.Controls.Add(li);
            }                        
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //Resgata o argumento que foi configurado para cada LinkButton
            string idComandaProduto = (sender as ImageButton).CommandArgument;

            ControllerComandaProduto.deleteComandaProduto(Convert.ToInt32(idComandaProduto));

            //Muda o botão Pedido para o número de produtos no Pedido(Comanda_Produto)
            int i = ControllerComandaProduto.getNumeroProdutosNoPedido();
            Session["nComandaPedido"] = i;
            Response.Redirect("~/Mobile/Pages/Pedidos.aspx");
        }

        protected void btnEnviarPedido_Click(object sender, ImageClickEventArgs e)
        {
            List<ComandaProduto> lcp = ControllerComandaProduto.getComandaProduto();

            //Pega o maior número de IDPedido, soma um e envia pra atualizar no
            int idPedido = ControllerComandaProduto.getMaiorPedido();
            idPedido++;

            foreach (ComandaProduto comandaProd in lcp)
            {
                 ControllerComandaProduto.updateComandaProduto(comandaProd.idComandaProduto, idPedido);
            }

            //Muda o botão Pedido para o número de produtos no Pedido(Comanda_Produto)
            int i = ControllerComandaProduto.getNumeroProdutosNoPedido();
            Session["nComandaPedido"] = i;
            Response.Redirect("~/Mobile/Pages/Pedidos.aspx");
        }
    }
}