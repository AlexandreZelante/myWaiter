using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWaiter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["conta"] != null && Session["idMesa"] != null)
            {
                if(Session["currentUser"] != null)
                {
                    if (Session["currentUser"].ToString() == "Mesa " + Session["idMesa"].ToString())
                    {
                        Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Mobile/Pages/paginaComandas.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Admin/Home/Home.aspx");
            }    
        }
    }
}