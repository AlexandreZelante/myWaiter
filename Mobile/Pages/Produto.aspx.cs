using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class Produto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        public void FillPage()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Produto p = ControllerProduto.getProdutoById(id);

            imgProduto.ImageUrl = p.imagem;
            lblNome.Text = p.nome_Produto;
            lblDescricao.Text = p.descricao_Produto;
            if(p.disponibilidade_Produto == 0)
            {
                lblPreco.Text = "Produto indisponível";
                imgAddAoPedido.Visible = false;
            }
            else
            {
                lblPreco.Text = "R$ " + p.preco_produto.ToString("F");
            }     
        }


        protected void imgUp_Click(object sender, ImageClickEventArgs e)
        {
            int n = Convert.ToInt32(txtNumero.Text);
            if (n < 15)
            {
                n++;
                txtNumero.Text = n.ToString();
            }
            else if (n == 15)
            {
                txtNumero.Text = Convert.ToString(15);
            }
            else
            {
                txtNumero.Text = Convert.ToString(15);
            }   
        }

        protected void imgDown_Click(object sender, ImageClickEventArgs e)
        {
            int n = Convert.ToInt32(txtNumero.Text);
            if (n > 1)
            {
                n--;
                txtNumero.Text = n.ToString();
            }
            else if (n == 1)
            {
                txtNumero.Text = Convert.ToString(1);
            }
            else
            {
                txtNumero.Text = Convert.ToString(1);
            }                    
        }

        //protected void btnAddAoPedido_Click(object sender, ImageClickEventArgs e)
        //{
        //    int qtde = Convert.ToInt32(txtNumero.Text);
        //    int idProd = Convert.ToInt32(Request.QueryString["id"]);
        //    int idCurrentUser = Convert.ToInt32(Session["idCurrentUser"].ToString());
        //    int idConta = Convert.ToInt32(Session["conta"]);

        //    //Insere a Comanda_Produto
        //    ControllerComandaProduto.inserirComandaProduto(qtde, idProd, idCurrentUser, idConta);

        //    //Muda o botão Pedido para o número de produtos no Pedido(Comanda_Produto)
        //    int i = ControllerComandaProduto.getNumeroProdutosNoPedido();
        //    Session["nComandaPedido"] = i;
        //    Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
        //}

        protected void Yes_Click(object sender, EventArgs e)
        {
            int qtde = Convert.ToInt32(txtNumero.Text);
            int idProd = Convert.ToInt32(Request.QueryString["id"]);
            int idCurrentUser = Convert.ToInt32(Session["idCurrentUser"].ToString());
            int idConta = Convert.ToInt32(Session["conta"]);

            //Insere a Comanda_Produto
            ControllerComandaProduto.inserirComandaProduto(qtde, idProd, idCurrentUser, idConta);

            //Muda o botão Pedido para o número de produtos no Pedido(Comanda_Produto)
            int i = ControllerComandaProduto.getNumeroProdutosNoPedido();
            Session["nComandaPedido"] = i;
            Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string categoria = ControllerProduto.getCategoriaProduto(id);

            Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx?cat=" + categoria);
        }
    }
}