using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Model
{
    public class ComandaProduto
    {
        public int idComandaProduto { get; set; }
        public int qtdeItemComanda { get; set; }
        public int fk_idProduto { get; set; }
        public int fk_idComanda { get; set; }
        public int statusComanda { get; set; }
        public int fk_idConta { get; set; }
        public double valorComandaProduto { get; set; }

        public ComandaProduto(int idComanda, int qtdeItem, int fk_idProd, int fk_idComanda, int statusComanda, int fk_idConta)
        {
            this.idComandaProduto = idComanda;
            this.qtdeItemComanda = qtdeItem;
            this.fk_idProduto = fk_idProd;
            this.fk_idComanda = fk_idComanda;
            this.statusComanda = statusComanda;
            this.fk_idConta = fk_idConta;
        }
    }
}