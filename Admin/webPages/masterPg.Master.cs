using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Admin.webPages;

namespace myWaiter.Admin.webPages
{
    public partial class masterPg : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["conta"] != null)
                {
                    if (Convert.ToInt32(Session["permissao"]) == 0)
                    {
                        Response.Redirect("~/Mobile/Pages/paginaComandas.aspx");
                    }
                    else if (Convert.ToInt32(Session["permissao"]) == 1)
                    {
                        Response.Redirect("~/Admin/webPages/mainAdmin.aspx");
                    }
                    else if (Convert.ToInt32(Session["permissao"]) == 2)
                    {
                        Response.Redirect("~/Admin/webPages/pedidosCozinha.aspx");
                    }
                }
            }
        }
    }
}