using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Model;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class MasterHeader : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["conta"] != null && Session["idMesa"] != null)
                {
                    Fill_Page();
                }
                else
                {
                    Response.Redirect("~/Admin/Home/Home.aspx");
                }
            }
            else
            {
                Fill_Page();
            }
        }

        public void Fill_Page()
        {
            List<Comanda> lc = ControllerComanda.getComanda();

            foreach (Comanda comanda in lc)
            {
                //Instancia um novo LinkButton
                LinkButton lb = new LinkButton();
                //Configura o nome do texto do LinkButton
                lb.Text = comanda.nome_Pessoa;
                //Linka o evento click para um evento para esse botão
                lb.Click += LinkButton1_Click;
                //Cria um comando de argumento que é o texto do linkButton, esse argumento é rodado lá no evento de click
                lb.CommandArgument = comanda.idComanda.ToString();
                lb.ForeColor = System.Drawing.Color.PapayaWhip;
                lb.Font.Underline = true;
                lb.Font.Size = 12;
                lb.Font.Name = "Century Gothic";

                //Cria um novo Comando LI(HTML)
                HtmlGenericControl li = new HtmlGenericControl("li");               
                li.Attributes.Add("class", "lis");
                //Adiciona a esse LI o LinkButton criado e configurado anteriormente
                li.Controls.Add(lb);
                //Insere dentro do UL criado e configurado com o runat="server" no HTML
                ulNomes.Controls.Add(li);                
            }

            //Session["currentUser"] = Request.QueryString["currentUser"].ToString();
            //lblCurrentUser.Text = Session["currentUser"].ToString();

            //Muda as labels informativas informando o : Usuário atual e a mesa atual
            lblCurrentUser.Text = Session["currentUser"].ToString();
            lblCurrentMesa.Text = "Mesa " + Session["idMesa"].ToString();

            //Chama o método para mudar o número no botão Pedido
            fill_PagePedido(Convert.ToInt32(Session["nComandaPedido"]));

            if (Session["currentUser"].ToString() == "Mesa " + Session["idMesa"].ToString())
            {
                lblCurrentUser.Visible = false;
                btnAddComanda.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Resgata o argumento que foi configurado para cada LinkButton
            string idComanda = (sender as LinkButton).CommandArgument;

            Session["idCurrentUser"] = idComanda;

            string nome = ControllerComanda.getNomeComanda(Convert.ToInt32(idComanda));
            Session["currentUser"] = nome;

            Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
        }

        public void fill_PagePedido(int n)
        {
            if (n <= 20)
            {
                btnPedido.ImageUrl = string.Format("~/Mobile/images/pedido/{0}.fw.png", n);
            }
            else
            {
                btnPedido.ImageUrl = "~/Mobile/images/pedido/20m.fw.png";
            }
        }

        protected void btnExcluirComanda_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}