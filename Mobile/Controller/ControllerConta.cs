using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using myWaiter.Mobile.Model;

namespace myWaiter.Mobile.Controller
{
    public class ControllerConta
    {
        private static SqlConnection con;
        private static SqlCommand command;

        static ControllerConta()
        {
            string connectionString = ConnectionString.getConString();
            con = new SqlConnection(connectionString);
            command = new SqlCommand("", con);
        }

        

        public static int inserirConta(int idMesa)
        {
            command.Parameters.Clear();
            
            int idConta = 0;

            SqlCommand getIdCm = new SqlCommand();

            getIdCm.Parameters.Clear();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "addConta";
            command.Parameters.AddWithValue("@fk_idMesa", idMesa);
            command.Connection = con;

            getIdCm.CommandType = CommandType.StoredProcedure;
            getIdCm.CommandText = "getIdConta";
            getIdCm.Parameters.Add("@idConta", SqlDbType.Int);
            getIdCm.Parameters["@idConta"].Direction = ParameterDirection.Output;
            getIdCm.Connection = con;

            try
            {
                con.Open();

                command.ExecuteNonQuery();
                getIdCm.ExecuteNonQuery();
                idConta = (int)getIdCm.Parameters["@idConta"].Value;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
                getIdCm.Parameters.Clear();
            }
            return idConta;
        }

        public static List<ModelPedido> getModelConta(int idComanda)
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getContaComanda";
            command.Parameters.AddWithValue("@idComanda", idComanda);
            command.Parameters.AddWithValue("@idConta", conta);

            List<ModelPedido> lmp = new List<ModelPedido>();

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nomeProd = reader.GetString(0);
                    double valor = reader.GetDouble(2);
                    int qtde = reader.GetInt32(1);

                    ModelPedido mp = new ModelPedido(nomeProd, valor, qtde);

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

        public static void finalizarConta()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "finalizarConta";
            command.Parameters.AddWithValue("@idConta", conta);

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