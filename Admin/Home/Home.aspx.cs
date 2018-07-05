using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Model;
using myWaiter.Mobile.Controller;
using myWaiter.Admin.Controller;

namespace myWaiter
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["permissao"] != null)
                {
                    if (Convert.ToInt32(Session["permissao"]) == 0)
                    {
                        Response.Redirect("~/Mobile/Pages/pagina1.aspx");
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
            if (IsPostBack)
            {
                if (Session["permissao"] != null)
                {
                    if (Convert.ToInt32(Session["permissao"]) == 0)
                    {
                        Response.Redirect("~/Mobile/Pages/pagina1.aspx");
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

        public void newButton()
        {
            string login = txtUser.Text;
            string senha = txtPass.Text;

            List<Mesa> m = ControllerMesa.getMesa();

            foreach (Mesa mesa in m)
            {
                if (login == mesa.loginMesa && senha == mesa.senhaMesa)
                {
                    if (mesa.status_Mesa != 0)
                    {
                        MesaController mc = new MesaController();
                        if (mesa.permissaoUser == 0)
                        {
                            mc.ocuparMesa(mesa.id_Mesa);
                            Session["idMesa"] = mesa.id_Mesa;
                            Session["conta"] = ControllerConta.inserirConta(mesa.id_Mesa);
                            Session["permissao"] = mesa.permissaoUser;
                            Response.Redirect("~/Mobile/Pages/pagina1.aspx");
                        }
                        else if (mesa.permissaoUser == 1)
                        {
                            Session["permissao"] = mesa.permissaoUser;
                            Response.Redirect("~/Admin/webPages/mainAdmin.aspx");
                        }
                        else if (mesa.permissaoUser == 2)
                        {
                            Session["permissao"] = mesa.permissaoUser;
                            Response.Redirect("~/Admin/webPages/pedidosCozinha.aspx");
                        }
                    }
                    else
                    {
                        lblErroLog.Text = "Verifique a disponibilidade da mesa!";
                        return;
                    }
                }
                else
                {
                    lblErroLog.Text = "Verifique seu nome de usuário e senha!";
                }
            }
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            newButton();
        }

        protected void No_Click(object sender, EventArgs e)
        {

        }

    }
}