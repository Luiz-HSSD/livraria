using System;
using System.Collections.Generic;
using Dominio;
using Oracle.DataAccess.Client;
using Core.Utils;
using System.Data;

namespace Core.DAO
{
    public class EnderecoDAO : AbstractDAO
    {
        private Endereco endereco = new Endereco();
        public EnderecoDAO() : base( "enderco", "ende_id")
        {

        }

        public override void Alterar(EntidadeDominio entidade)
        {
            throw new NotImplementedException();
        }

        public override List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            connection.Open();
            endereco = (Endereco)entidade;
            string sql = null;

            
            if (endereco.ID != 0)
            {
                sql = "SELECT * FROM endereco";
            }
            else
            {
                sql = "SELECT * FROM endereco WHERE cep=:cep and bairro=:bairro and complemento=:comp and logradouro=:log and numero= :num and uf=:uf and  cidade=:cidade";
                
            }
            pst.Parameters.Clear();
            OracleParameter[] parameters = new OracleParameter[]
                    {
                            new OracleParameter("cep", endereco.Cep),
                            new OracleParameter("bairro", endereco.Bairro),
                            new OracleParameter("comp", ":"+endereco.Complemento),
                            new OracleParameter("log", endereco.Logradouro),
                            new OracleParameter("num", endereco.Numero),
                            new OracleParameter("uf", endereco.UF),
                            new OracleParameter("cidade", endereco.Cidade)
                    };
            pst.Parameters.Clear();
            pst.CommandText = sql;
            if (parameters != null) pst.Parameters.AddRange(parameters);
            pst.Connection = connection;
            vai = pst.ExecuteReader();
            List<EntidadeDominio> enderecos = new List<EntidadeDominio>();
            Endereco p;
            while (vai.Read())
            {
                p = new Endereco()
                {
                    ID = Convert.ToInt32(vai["ende_id"]),
                    Cep = (vai["cep"].ToString()),
                    Bairro = (vai["bairro"].ToString()),
                    Complemento = (vai["complemento"].ToString().Substring(1)),
                    Logradouro = (vai["logradouro"].ToString()),
                    Numero = (vai["numero"].ToString()),
                    UF = (vai["uf"].ToString()),
                    Cidade = (vai["cidade"].ToString())
                };
                enderecos.Add(p);
            }

            connection.Close();
            return enderecos;

        }

        public override void Salvar(EntidadeDominio entidade)
        {
            connection.Open();
            endereco = (Endereco)entidade;
            pst.Dispose();
            pst.CommandText = "insert into endereco(cep, bairro, complemento, logradouro ,numero ,uf , cidade ) values ( :cep , :bairro, :comp , :log , :num, :uf, :cidade )";
            OracleParameter[] parameters = new OracleParameter[]
                    {
                            new OracleParameter("cep", endereco.Cep),
                            new OracleParameter("bairro", endereco.Bairro),
                            new OracleParameter("comp", ":"+endereco.Complemento.ToString()),
                            new OracleParameter("log", endereco.Logradouro),
                            new OracleParameter("num", endereco.Numero),
                            new OracleParameter("uf", endereco.UF),
                            new OracleParameter("cidade", endereco.Cidade)
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
