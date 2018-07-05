using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Controller
{
    public class ControllerProduto
    {
        private static SqlConnection con;
        private static SqlCommand command;

        static ControllerProduto()
        {
            string connectionString = ConnectionString.getConString();
            con = new SqlConnection(connectionString);
            command = new SqlCommand("", con);
        }

        public static List<Produto> getProdutoByCategoria(string categoria)
        {
            List<Produto> lp = new List<Produto>();
            command.CommandType = CommandType.Text;
            string comando = string.Format("SELECT id_Produto, nome_Produto, preco_Produto, categoria_Produto, descricao_Produto, img_src, disponibilidade_Produto FROM Produto WHERE categoria_Produto = '{0}'", categoria);

            try
            {
                con.Open();
                command.CommandText = comando;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    double preco = reader.GetDouble(2);
                    string cat = reader.GetString(3);
                    string descricao = reader.GetString(4);
                    string img = reader.GetString(5);
                    int disp = reader.GetInt32(6);

                    Produto prod = new Produto(id, nome, preco, cat, descricao, img, disp);
                    lp.Add(prod);
                }

            }
            finally
            {
                con.Close();
            }

            return lp;
        }

        public static List<Produto> getProdutoByPrioridade()
        {
            List<Produto> lp = new List<Produto>();
            command.CommandType = CommandType.Text;
            string comando = string.Format("SELECT id_Produto, nome_Produto, preco_Produto, categoria_Produto, descricao_Produto, img_src, disponibilidade_Produto FROM Produto ORDER BY prioridade_Produto desc, nome_Produto");

            try
            {
                con.Open();
                command.CommandText = comando;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    double preco = reader.GetDouble(2);
                    string cat = reader.GetString(3);
                    string descricao = reader.GetString(4);
                    string img = reader.GetString(5);
                    int disp = reader.GetInt32(6);

                    Produto prod = new Produto(id, nome, preco, cat, descricao, img, disp);
                    lp.Add(prod);
                }

            }
            finally
            {
                con.Close();
            }

            return lp;
        }

        //O método com DataTable
        /*public static List<Produto> getProdutoByCategorias(string categoria)
        {
            List<Produto> lp = new List<Produto>();
            DataTable dtProduto = new DataTable();
            SqlDataAdapter daProduto = new SqlDataAdapter("getProdutoByCategoria", con);

            daProduto.SelectCommand.CommandType = CommandType.StoredProcedure;

            daProduto.SelectCommand.Parameters.AddWithValue("@categoria", categoria);
         

            try
            {
              foreach (DataRow linha in dtProduto.Rows)
              {
                int id = Convert.ToInt32(linha["id_Produto"]); //o "nome" é o nome da coluna, aí você tem que converter corretamente e passar as variaveis
                string nome = linha["nome_Produto"].ToString();
                double preco = Convert.ToDouble(linha["preco_Produto"]);
                string cat = linha["categoria_Produto"].ToString();
                //Eu tirei a subcategoria por causa das bebidas, criar outro método pra ter bebida
                string descricao = linha["descricao_Produto"].ToString();
                int quantidade = Convert.ToInt32(linha["quantiade_Produto"]);
                int prioridade = Convert.ToInt32(linha["prioridade_Produto"]);
                int disponibilidade = Convert.ToInt32(linha["disponibilidade_Produto"]);
                string imagem = linha["img_src"].ToString();

                Produto prod = new Produto(id, nome, preco, cat, descricao, quantidade, prioridade, disponibilidade, imagem);
                lp.Add(prod);
              }

            }
            finally
            {
                con.Close();
            }
            return lp;
        }*/

        public static Produto getProdutoById(int idProd)
        {
            try
            {
                con.Open();
                command.CommandText = string.Format("SELECT id_Produto, nome_Produto, preco_Produto, categoria_Produto, descricao_Produto, img_src, disponibilidade_Produto FROM Produto WHERE id_Produto = {0}", idProd);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                int id = reader.GetInt32(0);
                string nome = reader.GetString(1);
                double preco = reader.GetDouble(2);
                string cat = reader.GetString(3);
                string descricao = reader.GetString(4);
                string img = reader.GetString(5);
                int disp = reader.GetInt32(6);

                Produto prod = new Produto(id, nome, preco, cat, descricao, img, disp);

                return prod;
            }
            finally
            {
                con.Close();
            }
        }

        public static string getCategoriaProduto(int id)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT categoria_Produto FROM Produto WHERE id_Produto = {0}", id);

            try
            {
                con.Open();
                string cat = Convert.ToString(command.ExecuteScalar());
                return cat;
            }
            finally
            {
                con.Close();
            }
        }
    }
}