using System.Data;
using MySql.Data.MySqlClient;

namespace FJD_REST.DLL
{
    public class Conexao
    {
        //MySqlConnection con = new MySqlConnection(@"
        //    Server=localhost;
        //    Database=intranet;
        //    user id=root;
        //    Pwd='';
        //    CharSet=utf8;");

        MySqlConnection con = new MySqlConnection(@"
            Server=EBER-NOTE;
            Database=intranet;
            user id=eber;
            Pwd='eber';
            CharSet=utf8;");

        public MySqlConnection Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public MySqlConnection Desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}