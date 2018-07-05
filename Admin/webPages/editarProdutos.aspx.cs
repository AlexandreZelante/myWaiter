using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Admin.webPages;
using myWaiter.Admin.Controller;

namespace myWaiter.Admin.webPages
{
    public partial class editarProdutos : System.Web.UI.Page
    {
        ProdutoController p;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["idProd"] = 0;
        }

        protected void gvProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gvProd.SelectedRow;
            int id = Convert.ToInt32(gr.Cells[1].Text);
            String nomeProd = gr.Cells[2].Text;
            String catProd = gr.Cells[3].Text;
            String priorProd = gr.Cells[5].Text;
            int qtdProd = Convert.ToInt32(gr.Cells[6].Text);
            double precoProd = Convert.ToDouble(gr.Cells[7].Text);
            Session.Timeout = 999;
            Session["idProd"] = id;
            Session["nomeProd"] = nomeProd;
            Session["catProd"] = catProd;
            if (priorProd.Equals("Alta"))
            {
                Session["priorProd"] = 1;
            }
            else
            {
                Session["priorProd"] = 0;
            }
            p = new ProdutoController();
            Session["descProd"] = p.getDesc(id);
            Session["qtdProd"] = qtdProd;
            Session["precoProd"] = precoProd;
            Response.Redirect("~/Admin/webPages/editarProdutoSelecionado.aspx");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ProdutoController p = new ProdutoController();
            if (txtNomeProd_Pesq.Text.Trim() != "")
            {
                gvProd.DataSource = p.searchProd(txtNomeProd_Pesq.Text);
                gvProd.DataBind();
            }
            else
            {
                gvProd.DataSource = p.getAllProd();
                gvProd.DataBind();
            }
        }
    }
}