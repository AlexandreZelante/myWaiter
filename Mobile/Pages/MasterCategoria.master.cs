using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWaiter
{
    public partial class MasterCategoria : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSalada_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Saladas");    
            
            /*//Se a pagina atual não for a produtos categoria, redireciona pra lá, MAS COM A QUERYSTRING DA CATEGORIA ATUAL
            if (HttpContext.Current.Request.Url.AbsolutePath != "/produtosCategoria.aspx")
            {                                     //QUERYSTRING DA CAT AQUI
                Response.Redirect("produtosCategoria.aspx?cat=salada");
            }
            else
            {
                //Se já estiver na pagina atual roda normal
                ((produtosCategoria)ContentPlaceHolderConteudos.Page).Fill_Page("salada");
            }*/                                         
           
        }

        protected void btnBebida_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Bebidas"); 

            //((produtosCategoria)ContentPlaceHolderConteudos.Page).Fill_Page("Roberto");
        }

        protected void btnPrato_Click(object sender, ImageClickEventArgs e)
        {
             Response.Redirect("produtosCategoria.aspx?cat=Prato_Feito");
        }

        protected void btnBurger_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Burger");
        }

        protected void btnPorcao_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Porçoes");
        }

        protected void btnPeixe_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Peixes");
        }

        protected void btnSanduiche_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Sanduíches");
        }

        protected void btnMassa_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Pasta_E_Cia");
        }

        protected void btnGrelhado_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Grelhados");
        }

        protected void btnSobremesa_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("produtosCategoria.aspx?cat=Sobremesas");
        }
    }
}