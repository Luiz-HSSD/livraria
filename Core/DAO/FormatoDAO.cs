using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Oracle.DataAccess.Client;
using System.Data;

namespace Core.DAO
{
    public class FormatoDAO : AbstractDAO
    {
        private Formato formato = new Formato(); 
        public FormatoDAO() : base("", "")
        {
        }

        public override void Alterar(EntidadeDominio entidade)
        {
            throw new NotImplementedException();
        }

        public override List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            connection.Open();
            formato = (Formato)entidade;
            string sql = null;


            if (formato.ID == 0)
            {
                sql = "SELECT * FROM formato";
            }
            else
            {
                sql = "SELECT * FROM formato WHERE id_for=:autor";

            }
            pst.Parameters.Clear();
            OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter(":autor", formato.ID)
                    };
            pst.Parameters.Clear();
            pst.CommandText = sql;
            if (parameters != null) pst.Parameters.AddRange(parameters);
            pst.Connection = connection;
            vai = pst.ExecuteReader();
            List<EntidadeDominio> entidades = new List<EntidadeDominio>();
            Autor p;
            while (vai.Read())
            {
                p = new Autor()
                {
                    ID = Convert.ToInt32(vai["id_for"]),
                    Nome = (vai["nome_aut"].ToString()),
                    Ativo = Convert.ToChar(vai["ativo_aut"].ToString())
                };
                entidades.Add(p);
            }

            connection.Close();
            return entidades;
        }

        public override void Salvar(EntidadeDominio entidade)
        {
            connection.Open();
            formato = (Formato)entidade;
            pst.Dispose();
            pst.CommandText = "insert into formato (cod_Formato, altura, largura, diametro, comprimento , peso , dimensoes ) values ( :cod , :altura, :larg , :diame , :compr , :peso , :dimen )";
            OracleParameter[] parameters = new OracleParameter[]
                    {
                            new OracleParameter("cod", formato.CodFormato),
                            new OracleParameter("altura", formato.Altura),
                            new OracleParameter("larg", formato.Largura),
                            new OracleParameter("diame", formato.Diametro),
                            new OracleParameter("compr", formato.Comprimento),
                            new OracleParameter("peso", formato.Peso),
                            new OracleParameter("dimen", formato.Dimensoes)
                    };


            pst.Parameters.Clear();
            pst.Parameters.AddRange(parameters);
            pst.Connection = connection;
            pst.CommandType = CommandType.Text;
            pst.ExecuteNonQuery();
            pst.CommandText = "commit work";
            pst.ExecuteNonQuery();
            connection.Close();
            return;
        }
    }
}
