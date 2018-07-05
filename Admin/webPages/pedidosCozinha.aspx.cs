using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using myWaiter.Mobile.Model;
using myWaiter.Mobile.Controller;

namespace myWaiter
{
    public partial class pedidosCozinha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill_Page();
        }

        public void Fill_Page()
        {
            List<int> lstIdPedido = ControllerComandaProduto.getIdPedido();

            foreach (int mp in lstIdPedido)
            {
                HtmlTable table = new HtmlTable();
                table.Attributes.Add("class", "tableCozinha");

                //
                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell td = new HtmlTableCell();
                td.Attributes.Add("class", "tdMesa");
                td.ColSpan = 2;
                

                tr.Controls.Add(td);
                //

                //
                HtmlTableRow tr2 = new HtmlTableRow();

                HtmlTableCell td2 = new HtmlTableCell();
                td2.ColSpan = 2;

                ImageButton imgBtn = new ImageButton();
                imgBtn.ImageUrl = "~/Admin/srcs/btnPreparado2.fw.png";
                imgBtn.ID = mp.ToString();
                imgBtn.Click += Preparado_Click;
                imgBtn.CommandArgument = mp.ToString();

                td2.Controls.Add(imgBtn);

                tr2.Controls.Add(td2);
                //

                table.Controls.Add(tr);
                table.Controls.Add(tr2);

                List<ModelPedido> ped = ControllerComandaProduto.getProdutosPedido(mp);

                foreach(ModelPedido pedido in ped)
                {
                    td.InnerText = "Mesa " + pedido.idMesa; //Nome da mesa aqui

                    //------------Td que será dinamicamente criada

                    HtmlTableRow tr3 = new HtmlTableRow();

                    HtmlTableCell td3 = new HtmlTableCell();
                    td3.InnerText = pedido.nome_Produto; //NOME PRODUTO

                    HtmlTableCell td4 = new HtmlTableCell();
                    td4.InnerText = pedido.qtdeItemComanda.ToString(); //QTDE PRODUTO

                    tr3.Controls.Add(td3);
                    tr3.Controls.Add(td4);

                    table.Controls.Add(tr3);                
                }
                lblTable.Controls.Add(table);
            }        
        }

        protected void Preparado_Click(object sender, ImageClickEventArgs e)
        {
            string idPedido = (sender as ImageButton).CommandArgument;

            ControllerComandaProduto.updateStatusComandaProdutoCozinha(Convert.ToInt32(idPedido));
            Response.Redirect("~/Admin/webPages/pedidosCozinha.aspx");
        }
    }
}