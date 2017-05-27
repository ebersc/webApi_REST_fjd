using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using FJD_REST.Models;

namespace FJD_REST.DLL
{
    public class HistoricoDLL
    {
        Conexao c = new Conexao();
        //Historico bll = new Historico();

        public List<Historico> Boletim(Historico bll)
        {
            List<Historico> j = new List<Historico>();
            try
            {
                //string j = "";

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = c.Conectar();
                cmd.CommandText = @"SELECT d.disciplina, h.semestre, h.ano, h.conceito, (h.faltas1 + h.faltas2 + h.faltas3 + h.faltas4 + h.faltas5) as faltastot,
                                        ((h.notas1 + h.notas2) / 2) as media, h.codobservacao, h.notas1, h.notas2  FROM historico as h
                                        join disciplinas as d on h.coddisciplina = d.coddisciplina
                                        WHERE h.ano LIKE YEAR(NOW()) AND h.semestre LIKE(IF(MONTH(NOW()) <= 6, 1, 2)) AND h.RA LIKE @RA";
                cmd.Parameters.AddWithValue("@RA", bll.Ra);
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bll.Disciplina = dr["disciplina"].ToString();
                    bll.Semestre = dr["semestre"].ToString();
                    bll.Ano = dr["ano"].ToString();
                    bll.Conceito = dr["conceito"].ToString();
                    bll.Faltastot = dr["faltastot"].ToString();
                    bll.Media = dr["media"].ToString();
                    bll.CodObservacao = dr["codobservacao"].ToString();
                    bll.Notas1 = dr["notas1"].ToString();
                    bll.Notas2 = dr["notas2"].ToString();
                    j.Add(bll);
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
    }
}