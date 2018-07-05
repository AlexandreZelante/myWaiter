using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using myWaiter.Mobile.Model;
using System.Data;

namespace myWaiter.Mobile.Controller
{
    public class ControllerMesa
    {
        private static SqlConnection con;
        private static SqlCommand command;

        static ControllerMesa()
        {
            string connectionString = ConnectionString.getConString();
            con = new SqlConnection(connectionString);
            command = new SqlCommand("", con);
        }

        public static List<Mesa> getMesa()
        {
            List<Mesa> lm = new List<Mesa>();

            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id_Mesa, status_Mesa, loginMesa, senhaMesa, permissaoUser FROM Mesa";

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int status = reader.GetInt32(1);
                    string login = reader.GetString(2);
                    string senha = reader.GetString(3);
                    int permissao = reader.GetInt32(4);

                    Mesa m = new Mesa(id, status, login, senha, permissao);
                    lm.Add(m);
                }
            }
            finally
            {
                con.Close();
            }

            return lm;
        }

        public static void disponibilizarMesa(int idMesa)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "disponibilizarMesa";
            command.Parameters.AddWithValue("@idMesa", idMesa);

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