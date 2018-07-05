using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Model
{
    public class ModelPedido
    {
        public string nome_Pessoa { get; set; }
        public int idComandaProduto { get; set; }
        public int qtdeItemComanda { get; set; }
        public int statusComanda { get; set; }
        public int fk_idConta { get; set; }
        public double valorComandaProduto { get; set; }
        public string imagem { get; set; }
        public string nome_Produto { get; set; }
        public double somaProdutoNoPedido { get; set; }
        public int idComanda { get; set; }
        public int idMesa { get; set; }

        public ModelPedido(string nomePessoa, int idComandaProd, int qtdeItemComanda, int statusComanda, int fk_idConta, double valorComandaProduto, string img, string nome_Prod)
        {
            this.nome_Pessoa = nomePessoa;
            this.idComandaProduto = idComandaProd;
            this.qtdeItemComanda = qtdeItemComanda;
            this.statusComanda = statusComanda;
            this.fk_idConta = fk_idConta;
            this.valorComandaProduto = valorComandaProduto;
            this.imagem = img;
            this.nome_Produto = nome_Prod;
        }

        public ModelPedido(string nome_Pessoa, int id_Comanda, double somaProdPed)
        {
            this.nome_Pessoa = nome_Pessoa;
            this.idComanda = id_Comanda;
            this.somaProdutoNoPedido = somaProdPed;
        }

        public ModelPedido(string nome, double valor, int qtde)
        {
            this.nome_Produto = nome;
            this.valorComandaProduto = valor;
            this.qtdeItemComanda = qtde;
        }

        public ModelPedido(int idMesa, string nomeProd, int qtde)
        {
            this.idMesa = idMesa;
            this.nome_Produto = nomeProd;
            this.qtdeItemComanda = qtde;
        }
    }
}