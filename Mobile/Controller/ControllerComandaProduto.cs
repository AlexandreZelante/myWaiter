using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using myWaiter.Mobile.Model;
using myWaiter.Mobile.Controller;

namespace myWaiter.Mobile.Controller
{
    public static class ControllerComandaProduto
    {
        private static SqlConnection con;
        private static SqlCommand command;

        static ControllerComandaProduto()
        {
            string connectionString = ConnectionString.getConString();
            con = new SqlConnection(connectionString);
            command = new SqlCommand("", con);
        }

        public static void inserirComandaProduto(int qtdeItem, int idProd, int idComanda, int idConta)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "addComanda_Produto";
            command.Parameters.AddWithValue("@qtd_Item", qtdeItem);
            command.Parameters.AddWithValue("@fk_idProd", idProd);
            command.Parameters.AddWithValue("@fk_idComanda", idComanda);
            command.Parameters.AddWithValue("@fk_idConta", idConta);
            
            try
            {
                con.Open();
                command.ExecuteNonQuery();     
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static int getNumeroProdutosNoPedido()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT COUNT(*) FROM Comanda_Produto WHERE status_ComandaProduto = 1 AND fk_idConta = {0}", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                int nProdutos = reader.GetInt32(0);
                return nProdutos;
            }
            finally
            {
                con.Close();
            }
        }

        public static List<ComandaProduto> getComandaProduto()
        {
            List<ComandaProduto> lc = new List<ComandaProduto>();
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            //Fazer os InnerJoins pra pegar o nome do Usuário que fez o pedido
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT id_Comanda_Produto, qtd_Item_Comanda, fk_idProduto, fk_idComanda, status_ComandaProduto, fk_idConta FROM Comanda_Produto WHERE fk_idConta = {0} AND status_ComandaProduto = 1", conta);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int idComandaProduto = reader.GetInt32(0);
                    int qtdeItemComanda = reader.GetInt32(1);
                    int fk_idProduto = reader.GetInt32(2);
                    int fk_idComanda = reader.GetInt32(3);
                    int status_ComandaProduto = reader.GetInt32(4);
                    int fk_idConta = reader.GetInt32(5);

                    ComandaProduto cp = new ComandaProduto(idComandaProduto, qtdeItemComanda, fk_idProduto, fk_idComanda, status_ComandaProduto, fk_idComanda);

                    lc.Add(cp);
                }

                return lc;
            }
            finally
            {
                con.Close();
            }
        }       

        public static void deleteComandaProduto(int id)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("DELETE Comanda_Produto WHERE id_Comanda_Produto = {0}", id);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public static List<ModelPedido> getModelPedido()
        {
            List<ModelPedido> lmp = new List<ModelPedido>();
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getModelPedido";
            command.Parameters.AddWithValue("@idConta", conta);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nomePessoa = reader.GetString(0);
                    int idComandaProduto = reader.GetInt32(1);
                    int qtdeItemComanda = reader.GetInt32(2);
                    int status_ComandaProduto = reader.GetInt32(3);
                    int fk_idConta = reader.GetInt32(4);
                    double valor_Comanda = reader.GetDouble(5);
                    string img = reader.GetString(6);
                    string nomeProd = reader.GetString(7);

                    ModelPedido mp = new ModelPedido(nomePessoa, idComandaProduto, qtdeItemComanda, status_ComandaProduto, fk_idConta, valor_Comanda, img, nomeProd);

                    lmp.Add(mp);
                }
                return lmp;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static List<ModelPedido> getNomePrecoComanda()
        {
            List<ModelPedido> lmp = new List<ModelPedido>();
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getNomePrecoComanda";
            command.Parameters.AddWithValue("@idConta", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    string nomeUser = reader.GetString(0);
                    int idComanda = reader.GetInt32(1);
                    double soma = reader.GetDouble(2);

                    ModelPedido mp = new ModelPedido(nomeUser, idComanda, soma);
                    lmp.Add(mp);
                }
                return lmp;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static void updateComandaProduto(int id, int idPedido)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "updateStatusComandaProduto";
            command.Parameters.AddWithValue("@idComandaProd", id);
            command.Parameters.AddWithValue("@idPedido", idPedido);

            SqlCommand command2 = new SqlCommand();
            command2.Connection = con;
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "updateValorTotalComanda";
            command2.Parameters.AddWithValue("@idComandaProduto", id);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
                command2.Parameters.Clear();
            }
        }

        public static int getNumeroComandaPedidoById(int idComanda)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getNumeroComandaPedidoById";
            command.Parameters.AddWithValue("@idComanda", idComanda);

            try
            {
                con.Open();
                int id = Convert.ToInt32(command.ExecuteScalar());
                return id;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
            
        }

        //Vê quantas comandas estão abertas ainda, pra se retornar 1  então ele fecha a conta
        public static int checarComandas()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checarComandas";
            command.Parameters.AddWithValue("@idConta", conta);

            try
            {
                con.Open();
                int qtde = Convert.ToInt32(command.ExecuteScalar());
                return qtde;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        //Checa para ver se há ComandasProduto com determinada comanda
        public static int checarComandaProduto(int idComanda)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checarComandaProduto";
            command.Parameters.AddWithValue("@idComanda", idComanda);

            try
            {
                con.Open();
                int qtde = Convert.ToInt32(command.ExecuteScalar());
                return qtde;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static int getMaiorPedido()
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MAX(id_Pedido) FROM Comanda_Produto";

            try
            {
                con.Open();
                int comanda = Convert.ToInt32(command.ExecuteScalar());
                return comanda;
            }
            finally
            {
                con.Close();      
            }
        }

        public static List<int> getIdPedido()
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "select distinct(id_pedido) from comanda_Produto WHERE status_ComandaProduto = 2 AND id_Pedido IS NOT NULL";
            List<int> lst = new List<int>();

            try
            {
                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idPedido = reader.GetInt32(0);
                    lst.Add(idPedido);
                }
                return lst;
            }
            finally
            {
                con.Close();
            }
        }

        public static List<ModelPedido> getProdutosPedido(int idPedido)
        {
            List<ModelPedido> lmp = new List<ModelPedido>();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getPedidos";
            command.Parameters.AddWithValue("@idPedido", idPedido);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nomeProd = reader.GetString(1);
                    int qtde = reader.GetInt32(2);

                    ModelPedido mp = new ModelPedido(id, nomeProd, qtde);

                    lmp.Add(mp);
                }
                return lmp;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static void updateStatusComandaProdutoCozinha(int id)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "updateStatusComandaProdutoCozinha";
            command.Parameters.AddWithValue("@idPedido", id);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }
    }
}