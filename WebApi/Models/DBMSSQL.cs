using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class DBMSSQL
    {
        public string ConnectionString { get; set; }

        public DBMSSQL(string connString)
        {
            this.ConnectionString = connString;
        }

        public int ExecuteNonQuery(string tsql, List<object[]> parametros)
        {
            SqlConnection conexao = new SqlConnection(this.ConnectionString);
            SqlCommand comando = new SqlCommand(tsql, conexao);

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    comando.Parameters.AddWithValue(item[0].ToString(), item[1]);
                }
            }

            int linhas = 0;

            try
            {
                conexao.Open();
                linhas = comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                conexao.Close();
                throw new Exception(ex.Message);
            }

            return linhas;
        }

        public object ExecuteScalar(string tsql, List<object[]> parametros)
        {
            SqlConnection conexao = new SqlConnection(this.ConnectionString);
            SqlCommand comando = new SqlCommand(tsql, conexao);

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    comando.Parameters.AddWithValue(item[0].ToString(), item[1]);
                }
            }

            object retoro;

            try
            {
                conexao.Open();
                retoro = comando.ExecuteScalar();
                conexao.Close();
            }
            catch (Exception ex)
            {
                conexao.Close();
                throw new Exception(ex.Message);
            }

            return retoro;
        }

        public DataTable ReturnDT(string tsql, List<object[]> parametros)
        {
            SqlConnection conexao = new SqlConnection(this.ConnectionString);
            SqlCommand comando = new SqlCommand(tsql, conexao);

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    comando.Parameters.AddWithValue(item[0].ToString(), item[1]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();

            try
            {
                conexao.Open();
                da.Fill(dt);
                conexao.Close();
            }
            catch (Exception ex)
            {
                conexao.Close();
                throw new Exception(ex.Message);
            }

            return dt;
        }
    }
}