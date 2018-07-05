using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using myWaiter.Admin.Model;
using myWaiter.Mobile.Controller;

namespace myWaiter.Admin.Controller
{
    public class PedidoController
    {
        Produto p;
        SqlConnection conn;

        public PedidoController()
        {
            conn = new SqlConnection(ConnectionString.getConString());
        }

        public List<ModelPedido> getPedidos()
        {
            List<ModelPedido> pedido = new List<ModelPedido>();
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ("getPedidos");
            try
            {
                conn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int idMesa = read.GetInt32(0);
                    string nomeProd = read.GetString(1);
                    int qtdProd = read.GetInt32(2);

                    ModelPedido pd = new ModelPedido();

                    pd.idMesa = idMesa;
                    pd.nome_Produto = nomeProd;
                    pd.qtdeItemComanda = qtdProd;

                    pedido.Add(pd);
                }
                return pedido;
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}