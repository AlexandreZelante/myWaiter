using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Model;
using myWaiter.Mobile.Controller;
using System.Web.UI.HtmlControls;

namespace myWaiter.Mobile.Pages
{
    public partial class Conta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill_Page();
        }

        public void Fill_Page()
        {
            List<Comanda> lc = ControllerComanda.getComandaConta();

            foreach (Comanda comanda in lc)
            {
                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tabelaConta");

                //--------------------------------------- Padrão, vai ter que ser criado em toda tabela
                HtmlTableRow tr1 = new HtmlTableRow();
                HtmlTableCell td1 = new HtmlTableCell();
                td1.Attributes.Add("class", "tdNome");
                td1.ColSpan = 2;
                td1.InnerText = comanda.nome_Pessoa; //Colocar o nome da comanda

                tr1.Controls.Add(td1);
                table.Controls.Add(tr1);
                //-----------------------------------------

                List<ModelPedido> lmp = ControllerConta.getModelConta(comanda.idComanda);

                foreach (ModelPedido modelPedido in lmp)
                {
                    //----------------------------------------- Criar um foreach para pegar os Produtos comanda
                    HtmlTableRow tr2 = new HtmlTableRow();
                    HtmlTableCell td2 = new HtmlTableCell();
                    td2.Attributes.Add("class", "auto-style1");
                    td2.InnerText = modelPedido.nome_Produto + " - " + modelPedido.qtdeItemComanda + " unid"; //Colocar o nome do Produto e a quantidade

                    HtmlTableCell td3 = new HtmlTableCell();
                    td3.InnerText = "R$ " + modelPedido.valorComandaProduto.ToString("F"); //Colcoar o valor da linha da ProdutoComanda

                    tr2.Controls.Add(td2);
                    tr2.Controls.Add(td3);


                    table.Controls.Add(tr2);
                    //------------------------------------------
                }
                lblTexto.Controls.Add(table);    
            }

            //<=========================================== Parte da Comanda(Nome e preço) ========>

            List<Comanda> lc2 = ControllerComanda.getComandaByStatus();

            foreach (Comanda comanda in lc2)
            {
                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tabelaContaComanda");

                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell td1 = new HtmlTableCell();
                td1.Attributes.Add("class", "nomePreco");
                td1.InnerText = comanda.nome_Pessoa + " - R$ " + comanda.valor_Total.ToString("F"); //Nome e valor total da comanda

                HtmlTableCell td2 = new HtmlTableCell();

                //Se estiverem logado como conta única o botão de fechamento de comanda única não será criado
                if (comanda.nome_Pessoa != "Mesa " + Session["idMesa"].ToString())
                {
                    //ImageButton btnComanda = new ImageButton();
                    //btnComanda.ImageUrl = "~/Mobile/images/conta/btnAccept.fw.png";
                    //btnComanda.Click += btnComanda_Click;
                    //btnComanda.CommandArgument = comanda.idComanda.ToString(); //Envia o id pelo parametro

                    //Se o numero de comandas for maior que 1 ela cria os botões
                    if (ControllerComandaProduto.checarComandas() > 1)
                    {
                        //-------------------- Imagem criada pra usar o javascript
                        Image img = new Image();
                        img.ID = comanda.idComanda.ToString();
                        if (ControllerComandaProduto.getNumeroComandaPedidoById(Convert.ToInt32(comanda.idComanda)) > 0)
                        {
                            img.ImageUrl = "~/Mobile/images/conta/btnAccept2.fw.png";
                        }
                        else
                        {
                            img.ImageUrl = "~/Mobile/images/conta/btnAccept.fw.png";
                            img.CssClass = "btnFinalizar_Click";
                        }                    
                        //--------------------
                        td2.Controls.Add(img);
                    }         
                    
                }
               
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);

                table.Controls.Add(tr);

                lblComandaConta.Controls.Add(table);

                //-------------------------- Parte do botão dinamico da msgbox

                ImageButton imgBtnMsgBox = new ImageButton();
                imgBtnMsgBox.ID = "btn"+comanda.idComanda.ToString();
                imgBtnMsgBox.ImageUrl = "~/Mobile/images/msgBox/btnOk.fw.png";
                //imgBtnMsgBox.Attributes.Add("class", "btnOkBox");
                imgBtnMsgBox.Attributes.Add("class", "btnOkBox hidden btnContentMain_" + comanda.idComanda.ToString());
                //imgBtnMsgBox.Attributes.Add("class", "btnContentMain_" + comanda.idComanda.ToString());
                imgBtnMsgBox.Click += btnComanda_Click;
                imgBtnMsgBox.CommandArgument = comanda.idComanda.ToString();

                msgBoxProduto.Controls.Add(imgBtnMsgBox);
            }
        }

        protected void btnComanda_Click(object sender, ImageClickEventArgs e)
        {
            string idComanda = (sender as ImageButton).CommandArgument;

            ControllerComanda.finalizarComanda(Convert.ToInt32(idComanda));

            //Pega a comanda com o maior id para colocar nos currents
            Comanda c = ControllerComanda.getMaiorComandaUnica();
            Session["idCurrentUser"] = c.idComanda;
            Session["currentUser"] = c.nome_Pessoa;

            Response.Redirect("~/Mobile/Pages/Conta.aspx");  
        }

        public void finalizarConta()
        {
            ControllerConta.finalizarConta();

            Session["conta"] = null;
            Session["currentUser"] = null;    
            Session["permissao"] = null;
            Session["idCurrentUser"] = null;

            ControllerMesa.disponibilizarMesa(Convert.ToInt32(Session["idMesa"]));
            Session["idMesa"] = null;

            Response.Redirect("~/Mobile/Pages/telaFinal.aspx");

            //Response.Redirect() Para a tela de OBRIGADO POR USAR O MYWAITER
        }

        protected void btnFinalizarConta_Click(object sender, ImageClickEventArgs e)
        {
            finalizarConta(); 
        }
    }
}