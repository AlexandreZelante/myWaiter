using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using myWaiter.Mobile.Model;

namespace myWaiter.Mobile.Controller
{
    public static class ControllerComanda
    {
        private static SqlConnection con;
        private static SqlCommand command;

        static ControllerComanda()
        {
            string connectionString = ConnectionString.getConString();
            con = new SqlConnection(connectionString);
            command = new SqlCommand("", con);
        }

        public static void inserirComanda(string nome)
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("INSERT INTO Comanda(nome_Pessoa,hora_Comanda,status_Comanda,valor_Total,fk_idConta) VALUES('{0}',CURRENT_TIMESTAMP,1,0,{1})", nome, conta);

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

        public static void inserirComandaUnica()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            int idMesa = Convert.ToInt32(HttpContext.Current.Session["idMesa"]);

            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("INSERT INTO Comanda(nome_Pessoa, hora_Comanda, status_Comanda, valor_Total, fk_idConta) VALUES('Mesa {0}', CURRENT_TIMESTAMP, 1, 0, {1})", idMesa.ToString(), conta);

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

        //Pega todas as comandas com status 1 (Em aberto)
        public static List<Comanda>getComanda()
        {
            List<Comanda> lc = new List<Comanda>();

            command.CommandType = CommandType.Text;

            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandText = string.Format("SELECT id_Comanda, nome_Pessoa, status_Comanda, valor_Total, fk_idConta FROM Comanda WHERE fk_idConta = {0} AND status_Comanda = 1", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    int status = reader.GetInt32(2);
                    double total = reader.GetDouble(3);
                    int idconta = reader.GetInt32(4);

                    Comanda c = new Comanda(id, nome, status, total, idconta);
                    lc.Add(c);
                }
                return lc;
            }
            finally
            {
                con.Close();
            }
        }

        //Pega todas as comandas, independente do seu status. (Usada na verificação se já existe algum nome igual no BD)
        public static List<Comanda> getTodasComandas()
        {
            List<Comanda> lc = new List<Comanda>();

            command.CommandType = CommandType.Text;

            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandText = string.Format("SELECT id_Comanda, nome_Pessoa, status_Comanda, valor_Total, fk_idConta FROM Comanda WHERE fk_idConta = {0}", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    int status = reader.GetInt32(2);
                    double total = reader.GetDouble(3);
                    int idconta = reader.GetInt32(4);

                    Comanda c = new Comanda(id, nome, status, total, idconta);
                    lc.Add(c);
                }
                return lc;
            }
            finally
            {
                con.Close();
            }
        }

        //Pega todas as comandas em ordem das que ainda estão ativas (Feitas pra fazer a pagina de conta)
        public static List<Comanda> getComandaConta()
        {
            List<Comanda> lc = new List<Comanda>();

            command.CommandType = CommandType.Text;

            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandText = string.Format("SELECT id_Comanda, nome_Pessoa, status_Comanda, valor_Total, fk_idConta FROM Comanda WHERE fk_idConta = {0} ORDER BY status_Comanda DESC", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    int status = reader.GetInt32(2);
                    double total = reader.GetDouble(3);
                    int idconta = reader.GetInt32(4);

                    Comanda c = new Comanda(id, nome, status, total, idconta);
                    lc.Add(c);
                }
                return lc;
            }
            finally
            {
                con.Close();
            }
        }

        //Pega o nome da comanda atual (Usada pra colocar o nome da mesma nas labels)
        public static string getNomeComanda(int id)
        {
            command.CommandText = string.Format("SELECT nome_Pessoa FROM Comanda WHERE id_Comanda = {0}", id);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                string nome = reader.GetString(0);
                return nome;
            }
            finally
            {
                con.Close();
            }
        }

        public static int getIdComanda(string nome)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT MAX(id_Comanda) FROM Comanda WHERE nome_Pessoa = '{0}'", nome);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                int id = reader.GetInt32(0);
                return id;
            }
            finally
            {
                con.Close();
            }
        }

        //Pega todas apenas 3 colunas de todas as comandas com o staus 1
        public static List<Comanda> getComandaByStatus()
        {
            List<Comanda> lc = new List<Comanda>();
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getComandaByStatus";
            command.Parameters.AddWithValue("@idConta", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idComanda = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    double valor = reader.GetDouble(2);

                    Comanda c = new Comanda(idComanda, nome, valor);
                    lc.Add(c);
                }
                return lc;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        public static Comanda getMaiorComandaUnica()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getComandaUnica";
            command.Parameters.AddWithValue("@idConta", conta);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                int idComanda = reader.GetInt32(0);
                string nome = reader.GetString(1);
                double valor = reader.GetDouble(2);

                Comanda c = new Comanda(idComanda, nome, valor);

                return c;
            }
            finally
            {
                con.Close();
                command.Parameters.Clear();
            }
        }

        //Finaliza a comanda unica
        public static void finalizarComanda(int idComanda)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "finalizarComanda";
            command.Parameters.AddWithValue("@idComanda", idComanda);

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

        public static void deleteComanda(int idComanda)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "finalizarComanda";
            command.Parameters.AddWithValue("@idComanda", idComanda);

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

        public static int getCountComanda()
        {
            int conta = Convert.ToInt32(HttpContext.Current.Session["conta"]);
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT COUNT(*) FROM Comanda WHERE nome_Pessoa NOT LIKE 'Mesa%' AND fk_idConta = {0}", conta);

            try
            {
                con.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
            finally
            {
                con.Close();
            }
        }
    }
}