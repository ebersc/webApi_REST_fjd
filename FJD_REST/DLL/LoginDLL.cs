using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FJD_REST.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace FJD_REST.DLL
{
    public class LoginDLL
    {
        Login bll = new Login();
        Conexao c = new Conexao();

        public List<Login> DadosLogin()
        {
            List<Login> j = new List<Login>();
            try
            {
                //string j = "";

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = c.Conectar();
                cmd.CommandText = @"SELECT RA, SENHA FROM LOGIN;";
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bll.RA = dr["RA"].ToString();
                    bll.SENHA = dr["SENHA"].ToString();
                    j.Add(bll);
                    //j += JsonConvert.SerializeObject(bll) + ",";
                    //dr.NextResult();
                }
                dr.Close();


                return j;
            }
            catch (Exception ex)
            {
                //return "Não foi possivel conectar ao servidor.";
                return null;
            }
        }

        public bool BuscaLogin(Login bll)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = c.Conectar();
            cmd.CommandText = @"SELECT RA, SENHA FROM LOGIN WHERE RA=@USUARIO AND SENHA=@PASSWD;";
            cmd.Parameters.AddWithValue("@USUARIO", bll.RA);
            cmd.Parameters.AddWithValue("@PASSWD", bll.SENHA);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                if (bll.SENHA.Equals(dr["SENHA"].ToString()))
                {
                    dr.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    return false;
                }
            }
            else
            {
                dr.Close();
                return false;
            }

        }
    }
}