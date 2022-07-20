using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel
{
    class Conexao
    {
        public SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-NSBEM5J\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void desconectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DECLARAÇÃO DE OUTRAS VARIÁVEIS GLOBAIS
        

    }


}
