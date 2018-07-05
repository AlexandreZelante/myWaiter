using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using myWaiter.Admin.Controller;
using myWaiter.Admin.Model;

namespace myWaiter.Admin.webPages
{
    public partial class mesasAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillMesas();
        }

        public void fillMesas()
        {
            MesaController m = new MesaController();
            List<Mesa> lm = m.getAllMesas();

            foreach (Mesa mesa in lm)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl br = new HtmlGenericControl("br");
                Image img = new Image();

                if (mesa.status_Mesa == 1)
                {
                    img.ImageUrl = "~/Admin/srcs/mesagreen.fw.png";
                }
                else
                {
                    img.ImageUrl = "~/Admin/srcs/mesared.fw.png";
                }

                img.CssClass = "mesas";
                img.Height=200;

                Label idMesa = new Label();
                idMesa.Text = "Mesa " + mesa.id_Mesa;
                idMesa.CssClass = "lblIdMesa";

                HtmlGenericControl li = new HtmlGenericControl("li");

                //div.Controls.Add(img);
                //div.Controls.Add(idMesa);

                li.Controls.Add(img);
                li.Controls.Add(idMesa);

                ulImgs.Controls.Add(li);
            }
        }

        


    }
}