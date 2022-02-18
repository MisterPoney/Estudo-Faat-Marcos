using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaBancoDeDados17_02
{
    internal class Conexao
    {
        static private string server = "localhost";
        static private string database = "aula01";
        static private string username = "root";
        static private string password = "";
        static public string strConn = $"server={server}; " +
            $"User Id={username};password={password};" +
            $"database={database}";
        MySqlConnection cn;

        private bool Conectar()
        {
            bool resultado;
            try
            {
                cn = new MySqlConnection(strConn);
                cn.Open();
                resultado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resultado = false;
            }
            return resultado;
        }
        private void Desconectar()
        {
           if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
         
        }

        public bool Executa(string sql)
        {
            bool result;
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                result = true;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                Desconectar();
            }
            return result;
        }
        public DataTable Retorna(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                Conectar();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                return dt;
            }
            catch { return null; }
            finally
            {
                Desconectar();
            }
           
        }
      
    }
}
