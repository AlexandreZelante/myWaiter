using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Admin.Model
{
    public class Produto
    {

        public int id_Produto { get; set; }
        public string nome_Produto { get; set; }
        public double preco_produto { get; set; }
        public string categoria_Produto { get; set; }
        public string descricao_Produto { get; set; }
        public int quantidade_Produto { get; set; }
        public int prioridade_Produto { get; set; }
        public int disponibilidade_Produto { get; set; }
        public string imagem { get; set; }

        public Produto()
        {

        }

        public Produto(int id, string nome, double preco, string categoria, string descricao, string img, int disp)
        {
            this.id_Produto = id;
            this.nome_Produto = nome;
            this.preco_produto = preco;
            this.categoria_Produto = categoria;
            this.descricao_Produto = descricao;
            this.imagem = img;
            this.disponibilidade_Produto = disp;
        }

    }
}