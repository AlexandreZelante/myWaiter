using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using myWaiter.Mobile.Model;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class paginaComandas : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["conta"] != null && Session["idMesa"] != null)
            {
                if (Session["currentUser"] != null)
                {
                    int idMesa = Convert.ToInt32(HttpContext.Current.Session["idMesa"]);
                    if (Session["currentUser"].ToString() == "Mesa " + idMesa)
                    {
                        Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            adicionarComanda();         
        }
        
        public void adicionarComanda()
        {
            List<Comanda> lc = ControllerComanda.getComanda();

            foreach (Comanda comanda in lc)
            {
                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tableCriarComandas");

                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell td = new HtmlTableCell();

                HtmlTableCell td2 = new HtmlTableCell();
                td2.Attributes.Add("class", "tdBtnExcluir");

                ImageButton imgBtn = new ImageButton();
                imgBtn.Click += btnExcluir_Click;
                imgBtn.CommandArgument = comanda.idComanda.ToString();

                if (ControllerComandaProduto.checarComandaProduto(comanda.idComanda) == 0)
                {
                    imgBtn.ImageUrl = "~/Mobile/images/paginaComandas/btnDecline.fw.png";
                }
                else
                {
                    imgBtn.ImageUrl = "~/Mobile/images/paginaComandas/btnDecline2.fw.png";
                }
                
                Button bt = new Button();
                bt.Text = comanda.nome_Pessoa;
                bt.CssClass = "botoes";
                bt.Click += btnNome1_Click;
                //Você envia como argumento o ID da comanda atual PARA O EVENTO DE CLICK QUE FOI CRIADO LÁ EM BAIXO
                bt.CommandArgument = comanda.idComanda.ToString();

                bt.PostBackUrl = "~/Mobile/Pages/paginaComandas.aspx";
                //bt.PostBackUrl = "~/Mobile/Pages/produtosCategoria.aspx?currentUser=" + comanda.nome_Pessoa;

                td.Controls.Add(bt);
                td2.Controls.Add(imgBtn);

                tr.Controls.Add(td);
                tr.Controls.Add(td2);

                table.Controls.Add(tr);

                lblComandas.Controls.Add(table);
            }

            txtNome.Focus();            
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            List<Comanda> lc = ControllerComanda.getTodasComandas();

            string nome = txtNome.Text.Trim();

            if (nome == "Mesa " + Session["idMesa"].ToString() || nome == "" || nome == "Mesa 0" + Session["idMesa"].ToString())
            {
                lblErro.Text = "Não pode ser inserido esse nome!";
                return;
            }

            foreach (Comanda comanda in lc)
            {
                lblErro.Text = "";
                if (comanda.nome_Pessoa.ToUpper() == nome.ToUpper())
                {  
                    //Aprender e colocar messageBox aqui
                    lblErro.Text = "Já existe um usuário com esse nome!";                  
                    return;
                }
            }
            ControllerComanda.inserirComanda(nome);
            txtNome.Text = "";
            txtNome.Focus();
            Response.Redirect("~/Mobile/Pages/paginaComandas.aspx");
        }

        
        protected void btnNome1_Click(object sender, EventArgs e)
        {
            string idComanda = (sender as Button).CommandArgument;

            Session["idCurrentUser"] = idComanda;

            string nome = ControllerComanda.getNomeComanda(Convert.ToInt32(idComanda));
            Session["currentUser"] = nome;

            Response.Redirect("~/Mobile/Pages/produtosCategoria.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            string idComanda = (sender as ImageButton).CommandArgument;

            if (ControllerComandaProduto.checarComandaProduto(Convert.ToInt32(idComanda)) == 0)
            {
                ControllerComanda.deleteComanda(Convert.ToInt32(idComanda));
                Response.Redirect("~/Mobile/Pages/paginaComandas.aspx");
            }
            else
            {
                //MessageBox falando que essa comanda já fez pedidos!
            }
        } 
    }
}