using myWaiter.Admin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWaiter.Admin.webPages
{
    public partial class visualizarProdutoSelecionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["idProd"].ToString()) == 0 || Session["idProd"] == null)
            {
                Response.Redirect("visualizarProdutos.aspx");
            }
            else
            {
                ProdutoController p = new ProdutoController();
                imgProd.ImageUrl = p.getImg((int)Session["idProd"]);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarProdutoSelecionado.aspx");
        }
    }
}