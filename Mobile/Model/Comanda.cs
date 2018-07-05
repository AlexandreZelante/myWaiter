using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Model
{
    public class Comanda
    {
        public int idComanda { get; set; }
        public DateTime hora_Comanda { get; set; }
        public string nome_Pessoa { get; set; }
        public int status_Comanda { get; set; }
        public double valor_Total { get; set; }
        public int fk_idConta { get; set; }

        public Comanda()
        {

        }

        public Comanda(int id, string nome, int status, double valor, int idconta)
        {
            this.idComanda = id;
            this.nome_Pessoa = nome;
            this.status_Comanda = status;
            this.valor_Total = valor;
            this.fk_idConta = idconta;
        }

        public Comanda(int id, string nome, double valor)
        {
            this.idComanda = id;
            this.nome_Pessoa = nome;
            this.valor_Total = valor;
        }
    }
}