using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using myWaiter.Admin.Controller;
using myWaiter.Mobile.Controller;

namespace myWaiter.Admin.Controller
{
    public class Conta
    {
        private SqlConnection con;
        public int numeroMesa { get; set; }
        public int numeroConta { get; set; }
        public DateTime horaInicioConta { get; set; }
        public DateTime horaFimConta { get; set; }
        public int numeroComanda { get; set; }
        public string nomePessoa { get; set; }
        public DateTime horaInicioComanda { get; set; }
        public DateTime horaFimComanda { get; set; }
        public int codigoProduto { get; set; }
        public string nomeProduto { get; set; }
        public double valorPedido { get; set; }

        //public List<Conta> getAllContas()
        //{
        //    ConexaoAdmin cnn = new ConexaoAdmin();
        //    List<Conta> contas = new List<Conta>();
        //    SqlCommand cmd = new SqlCommand("", cnn.conectar());
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = ("getAllContas");
        //    con = new SqlConnection(cnn.CString());
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            int idMesa = reader.GetInt32(0);
        //            int idConta = reader.GetInt32(1);
        //            DateTime horaInicioConta = reader.GetDateTime(2);
        //            DateTime horaFimConta = reader.GetDateTime(3);
        //            int idComanda = reader.GetInt32(4);
        //            string nomePessoa = reader.GetString(5);
        //            DateTime horaInicioComanda = reader.GetDateTime(6);
        //            DateTime horaFimComanda = reader.GetDateTime(7);
        //            int idProduto = reader.GetInt32(8);
        //            string nomeProduto = reader.GetString(9);
        //            double valorComandaProduto = reader.GetDouble(10);

        //            Conta c = new Conta();
        //            c.codigoProduto = idProduto;
        //            c.horaFimComanda = horaFimComanda;
        //            c.horaFimConta = horaFimConta;
        //            c.horaInicioComanda = horaInicioComanda;
        //            c.horaInicioConta = horaInicioConta;
        //            c.nomePessoa = nomePessoa;
        //            c.nomeProduto = nomeProduto;
        //            c.numeroComanda = numeroComanda;
        //            c.numeroConta = numeroConta;
        //            c.numeroMesa = numeroMesa;
        //            c.valorPedido = valorPedido;
        //            contas.Add(c);
        //            int id = reader.GetInt32(0);
        //            int status = reader.GetInt32(1);

        //            Mesa m = new Mesa();
        //            m.IdMesa = id;
        //            m.StatusMesa = status;
        //            contas.Add(m);
        //        }
        //        return contas;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public DataSet getAllContas()
        {
            SqlCommand s = new SqlCommand("getAllContas", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds;
            try
            {
                con.Open();
                da.SelectCommand = s;
                ds = new DataSet();
                da.Fill(ds);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public Conta()
        {
            con = new SqlConnection(ConnectionString.getConString());
        }
    }
}