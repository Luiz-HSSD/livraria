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
    public class AutorDAO : AbstractDAO
    {
        private Autor autor = new Autor();
        public AutorDAO() : base("autor", "autor_id")
        {
        }

        public override void Alterar(EntidadeDominio entidade)
        {
            throw new NotImplementedException();
        }

        public override List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            connection.Open();
            autor = (Autor)entidade;
            string sql = null;


            if (autor.ID == 0)
            {
                sql = "SELECT * FROM autor";
            }
            else
            {
                sql = "SELECT * FROM autor WHERE autor_id=:autor";

            }
            pst.Parameters.Clear();
            OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter(":autor", autor.ID)
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
                    ID = Convert.ToInt32(vai["autor_id"]),
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
            {
                connection.Open();
                autor = (Autor)entidade;
                pst.Dispose();
                pst.CommandText = "insert into autor ( ativo_aut , nome_aut ) values ( 'A' , :nome )";
                OracleParameter[] parameters = new OracleParameter[]
                        {
                            new OracleParameter(":nome", autor.Nome)
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
}
