using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using myWaiter.Admin.Controller;
using myWaiter.Mobile.Controller;
using myWaiter.Admin.Model;

namespace myWaiter.Admin.Controller
{
    public class ProdutoController
    {
        Produto p;
        SqlConnection conn;

        //private string img;

        //public string Img
        //{
        //    get { return img; }
        //    set { img = value; }
        //}

        //private string nomeProd;

        //public string NomeProd
        //{
        //    get { return nomeProd; }
        //    set { nomeProd = value; }
        //}
        //private string categoriaProd;

        //public string CategoriaProd
        //{
        //    get { return categoriaProd; }
        //    set { categoriaProd = value; }
        //}
        
        //private int idProd;

        //public int IdProd
        //{
        //    get { return idProd; }
        //    set { idProd = value; }
        //}
        //private double precoProd;

        //public double PrecoProd
        //{
        //    get { return precoProd; }
        //    set { precoProd = value; }
        //}
        //private string descProd;

        //public string DescProd
        //{
        //    get { return descProd; }
        //    set { descProd = value; }
        //}
        //private int priorProd;

        //public int PriorProd
        //{
        //    get { return priorProd; }
        //    set { priorProd = value; }
        //}
        //private int dispProd;

        //public int DispProd
        //{
        //    get { return dispProd; }
        //    set { dispProd = value; }
        //}
        //private int qtdProd;

        //public int QtdProd
        //{
        //    get { return qtdProd; }
        //    set { qtdProd = value; }
        //}

        //public ProdutoAdmin()
        //{
        //    nomeProd = "";
        //    categoriaProd = "";
        //    idProd = 0;
        //    precoProd = 0;
        //    descProd = "";
        //    priorProd = 0;
        //    dispProd = 0;
        //}

        public ProdutoController()
        {
            conn = new SqlConnection(ConnectionString.getConString());
        }

        public void cadastrarProduto(Produto p)
        {
            
            SqlCommand add = new SqlCommand();
            add.CommandType = CommandType.StoredProcedure;
            add.CommandText = "addProd";

            add.Parameters.Add("@nome_Produto", SqlDbType.VarChar,40).Value = p.nome_Produto;
            add.Parameters.Add("@categoria_Produto", SqlDbType.VarChar, 40).Value = p.categoria_Produto;
            add.Parameters.Add("@prioridade_Produto", SqlDbType.Int).Value = p.prioridade_Produto;
            add.Parameters.Add("@quantidade_Produto", SqlDbType.Int).Value = p.quantidade_Produto;
            add.Parameters.Add("@img_src", SqlDbType.VarChar, 100).Value = p.imagem;
            add.Parameters.Add("@preco_Produto", SqlDbType.Float).Value = p.preco_produto;
            add.Parameters.Add("@descricao_Produto", SqlDbType.VarChar, 500).Value = p.descricao_Produto;
            add.Parameters.Add("@disponibilidade_Produto", SqlDbType.Int).Value = p.disponibilidade_Produto;

            
            
            try
            {
                conn.Open();
                add.Connection = conn;
                add.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                add.Parameters.Clear();
            }
        }

        public void editarProduto(Produto p)
        {
            
            SqlCommand edit = new SqlCommand();
            edit.CommandType = CommandType.StoredProcedure;
            edit.CommandText = "editProd";

            edit.Parameters.AddWithValue("@id_Produto", p.id_Produto);
            edit.Parameters.AddWithValue("@nome_Produto", p.nome_Produto);
            edit.Parameters.AddWithValue("@categoria_Produto", p.categoria_Produto);
            edit.Parameters.AddWithValue("@prioridade_Produto", p.prioridade_Produto);
            edit.Parameters.AddWithValue("@quantidade_Produto", p.quantidade_Produto);
            edit.Parameters.AddWithValue("@img_src", p.imagem);
            edit.Parameters.AddWithValue("@preco_Produto", p.preco_produto);
            edit.Parameters.AddWithValue("@descricao_Produto", p.descricao_Produto);
            edit.Parameters.AddWithValue("@disponibilidade_Produto", p.disponibilidade_Produto);

            try
            {
                conn.Open();
                edit.Connection = conn;
                edit.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                edit.Parameters.Clear();
            }
        }

        public DataSet searchProd(String nome)
        {
            SqlCommand s = new SqlCommand("viewProd " + "'"+nome+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds;
            try
            {
                conn.Open();
                da.SelectCommand = s;
                ds = new DataSet();
                da.Fill(ds);
            }
            finally
            {
                conn.Close();
            }
            
            return ds;
        }

        public string getDesc(int id)
        {
            SqlCommand s = new SqlCommand(string.Format("Select descricao_Produto from Produto where id_Produto= {0}", id), conn);
            SqlDataReader dr;
            string descricao="";
            try
            {
                conn.Open();
                dr = s.ExecuteReader();
                dr.Read();
                descricao = dr.GetString(0);
            }
            finally
            {
                conn.Close();
            }
            return descricao;
        }

        public string getImg(int id)
        {
            SqlCommand s = new SqlCommand("Select img_src from Produto where id_Produto=" + id+"", conn);
            SqlDataReader dr;
            string img = "";
            try
            {
                conn.Open();
                dr = s.ExecuteReader();
                dr.Read();
                img = dr.GetString(0);
            }
            finally
            {
                conn.Close();
            }
            return img;
        }

        public DataSet getAllProd()
        {
            SqlCommand s = new SqlCommand("select id_Produto as 'Id',nome_Produto as 'Produto',categoria_Produto as 'Categoria','Disponibilidade' = case when Produto.disponibilidade_Produto=1 then 'Disponivel' else 'Indisponível' end,'Prioridade' = case when Produto.prioridade_Produto=0 then 'Normal' else 'Alta' end, quantidade_Produto as 'Quantidade',preco_Produto as 'Preço (R$)' from Produto", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds;
            try
            {
                conn.Open();
                da.SelectCommand = s;
                ds = new DataSet();
                da.Fill(ds);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }
}