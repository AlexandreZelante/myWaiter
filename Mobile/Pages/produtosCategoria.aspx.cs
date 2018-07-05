using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class produtosCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //O post back é quando a pagina é chamada, e não resposta de alguma ação dela mesma
                if (Request.QueryString["cat"] == null)
                {
                    Fill_PageByPrioridade();
                }
                //Pega uma queryString que é a categoria que foi mandada lá da MasterCategoria, por que tava dando erro quando chamava de fora da pagina           
                string cat = Request.QueryString["cat"].ToString();
                Fill_Page(cat);
            }
            catch
            {

            }           
        }

        public void Fill_Page(string cat)
        {
            List<Produto> lp = ControllerProduto.getProdutoByCategoria(cat);

            foreach (Produto prod in lp)
            {
                LinkButton link = new LinkButton();
                link.ID = "LinkButton1";
                //link.Click += LinkButton1_Click;
                link.PostBackUrl = "Produto.aspx?id=" + prod.id_Produto;
                //Aqui em cima você define a postback url pra pagina produto enviando uma queryString do id do produto atual pra pagina

                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tableProduto");

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td1 = new HtmlTableCell();
                td1.RowSpan = 2;
                td1.Width = "155px";

                HtmlImage img = new HtmlImage();
                img.Src = prod.imagem;

                td1.Controls.Add(img);

                HtmlTableCell td2 = new HtmlTableCell();
                td2.Width = "550px";
                td2.InnerText = prod.nome_Produto ; 
                td2.Attributes["class"] = "nomeProdTab";

                HtmlTableCell td3 = new HtmlTableCell();
                td3.RowSpan = 2;
                td3.InnerText = "R$ " + prod.preco_produto.ToString("F");
                td3.Attributes["class"] = "precoProdTab";

                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);

                HtmlTableRow tr2 = new HtmlTableRow();
                HtmlTableCell td2Row2 = new HtmlTableCell();
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "divTexto");

                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = prod.descricao_Produto;

                div.Controls.Add(p);
                td2Row2.Controls.Add(div);
                tr2.Cells.Add(td2Row2);

                table.Rows.Add(tr);
                table.Rows.Add(tr2);

                link.Controls.Add(table);

                lblTexto.Controls.Add(link);

                link.CommandArgument = prod.id_Produto.ToString();
            }
        }

        public void Fill_PageByPrioridade()
        {
            List<Produto> lp = ControllerProduto.getProdutoByPrioridade();

            foreach (Produto prod in lp)
            {
                LinkButton link = new LinkButton();
                link.ID = "LinkButton1";
                //link.Click += LinkButton1_Click;
                link.PostBackUrl = "Produto.aspx?id=" + prod.id_Produto;
                //Aqui em cima você define a postback url pra pagina produto enviando uma queryString do id do produto atual pra pagina

                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tableProduto");

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td1 = new HtmlTableCell();
                td1.RowSpan = 2;
                td1.Width = "155px";

                HtmlImage img = new HtmlImage();
                img.Src = prod.imagem;

                td1.Controls.Add(img);

                HtmlTableCell td2 = new HtmlTableCell();
                td2.Width = "550px";
                td2.InnerText = prod.nome_Produto;
                td2.Attributes["class"] = "nomeProdTab";

                HtmlTableCell td3 = new HtmlTableCell();
                td3.RowSpan = 2;
                td3.InnerText = "R$ " + prod.preco_produto;
                td3.Attributes["class"] = "precoProdTab";

                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);

                HtmlTableRow tr2 = new HtmlTableRow();
                HtmlTableCell td2Row2 = new HtmlTableCell();
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "divTexto");

                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = prod.descricao_Produto;

                div.Controls.Add(p);
                td2Row2.Controls.Add(div);
                tr2.Cells.Add(td2Row2);

                table.Rows.Add(tr);
                table.Rows.Add(tr2);

                link.Controls.Add(table);

                lblTexto.Controls.Add(link);

                link.CommandArgument = prod.id_Produto.ToString();
            }
        }
        /*protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string idProduto = (sender as LinkButton).CommandArgument;
            Session["idProd"] = idProduto.ToString();       
            //((produto)Page).recebe(idProduto);
        }*/
    }
}