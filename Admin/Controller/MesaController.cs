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
    public class MesaController
    {
        private SqlConnection con;

        public MesaController()
        {
            con = new SqlConnection(ConnectionString.getConString());
        }

        public List<Mesa> getAllMesas()
        {
            List<Mesa> mesas = new List<Mesa>();
            SqlCommand cmd = new SqlCommand("",con);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("SELECT id_Mesa,status_Mesa from Mesa where permissaoUser=0");
            
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int status = reader.GetInt32(1);

                    Mesa m = new Mesa(id,status);
                    mesas.Add(m);
                }
                return mesas;
            }
            finally
            {
                con.Close();
            }
        }

        public void ocuparMesa(int id)
        {
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = string.Format("ocuparMesa");
            cmd.Parameters.AddWithValue("@idMesa", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}