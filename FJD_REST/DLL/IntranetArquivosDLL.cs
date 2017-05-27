using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using FJD_REST.Models;
using System.Text;
using System.Globalization;

namespace FJD_REST.DLL
{
    public class IntranetArquivosDLL
    {
        Conexao c = new Conexao();

        public List<Intranet_Arquivos> Arquivos(string ra)
        {
            List<Intranet_Arquivos> arq = new List<Intranet_Arquivos>();
            Intranet_Arquivos dados = new Intranet_Arquivos();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.Conectar();
                cmd.CommandText = @"SELECT p.PASTA, a.ARQUIVO, p.CODPROF, h.coddisciplina,
		                                    CONCAT('http://201.55.32.168/profs/arqs/', p.CODPROF, '/', a.ARQUIVO) AS Link
                                            FROM INTRANET_PASTAS AS p
                                            JOIN INTRANET_ARQUIVOS AS a ON p.ID_PASTA = a.ID_PASTA
                                            JOIN HISTORICO AS h ON p.coddi = h.coddisciplina
                                            WHERE h.RA=@RA ORDER BY p.PASTA ASC;";
                cmd.Parameters.AddWithValue("@RA", ra);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dados.Arquivo = dr["ARQUIVO"].ToString();
                    dados.Disciplina = dr["PASTA"].ToString();
                    dados.LinkArquivo = RemoveAcentucao(dr["Link"].ToString());
                    arq.Add(dados);
                }

                dr.Close();
                return arq;
            }
            catch
            {
                throw new Exception("Não foi possivel se conectar ao servidor!");
            }

            
        }

        string RemoveAcentucao(string link)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = link.Normalize(NormalizationForm.FormD)
                .ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter)
                    != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString().Replace(" ", "_");
        }
    }
}