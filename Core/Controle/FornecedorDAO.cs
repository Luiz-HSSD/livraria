using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;

namespace Core.DAO
{
    public class FornecedorDAO : AbstractDAO
    {
        public FornecedorDAO() : base("fornecedor", "forne_id")
        {
        }

        public override void Salvar(EntidadeDominio entidade)
        {
            connection.Open();
            Fornecedor fornecedor = (Fornecedor)entidade;
            Endereco endereco = fornecedor.ENDERECO;
            EnderecoDAO forn = new EnderecoDAO();
            List<EntidadeDominio> ende  = forn.Consultar(endereco);
            if (ende.Count > 0)
                fornecedor.ENDERECO = (Endereco) ende.ElementAt(0);
            else
            {
                forn.Salvar(fornecedor.ENDERECO);
                ende = forn.Consultar(fornecedor.ENDERECO);
                fornecedor.ENDERECO = (Endereco)ende.ElementAt(0);
            }
            pst.CommandText = "insert into fornecedor ( cnpj , fornecedor_nome, ende_id ) values ( :des , :nome , :ende )";
            parameters = new OracleParameter[]
                    {
                        new OracleParameter("des",fornecedor.CNPJ),
                        new OracleParameter("nome",fornecedor.Nome),
                        new OracleParameter("ende",fornecedor.ENDERECO.ID)
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

        public override void Alterar(EntidadeDominio entidade)
        {
            try
            {
                connection.Open();
                Fornecedor fornecedor = (Fornecedor)entidade;
                Endereco endereco = fornecedor.ENDERECO;
                EnderecoDAO forn = new EnderecoDAO();
                List<EntidadeDominio> ende = forn.Consultar(endereco);
                if (ende.Count > 0)
                    fornecedor.ENDERECO = (Endereco)ende.ElementAt(0);
                else
                {
                    forn.Salvar(fornecedor.ENDERECO);
                    ende = forn.Consultar(fornecedor.ENDERECO);
                    fornecedor.ENDERECO = (Endereco)ende.ElementAt(0);
                }
                pst.CommandText = "UPDATE fornecedor SET cnpj=:des, fornecedor_nome=:nome, ende_id=:ende WHERE forne_id=:co";
                parameters = new OracleParameter[]
                    {
                        new OracleParameter("des",fornecedor.CNPJ),
                        new OracleParameter("nome",fornecedor.Nome),
                        new OracleParameter("ende",fornecedor.ENDERECO.ID),
                        new OracleParameter("co",fornecedor.ID)

                    };
                pst.Parameters.Clear();
                pst.Parameters.AddRange(parameters);
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                vai = pst.ExecuteReader();
                vai.Read();
                pst.CommandText = "commit work";
                vai = pst.ExecuteReader();
                vai.Read();
                pst.ExecuteNonQuery();
                connection.Close();
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public override List<EntidadeDominio> Consultar(EntidadeDominio entidade)
        {
            try
            {
                connection.Open();
                pst.Dispose();
                Fornecedor categoria = (Fornecedor)entidade;
                string sql = null;

                if (categoria.Nome == null)
                {
                    categoria.Nome = "";
                }

                if (categoria.CNPJ == null)
                {
                    categoria.CNPJ = "";
                }

                if (categoria.ID == 0)
                {
                    sql = "SELECT * FROM fornecedor left join endereco using(ende_id)";
                }
                else
                {
                    sql = "SELECT * FROM fornecedor left join endereco using(ende_id) WHERE forne_id= :co";
                }


                pst.CommandText = sql;
                parameters = new OracleParameter[] { new OracleParameter("co", categoria.ID.ToString()) };
                pst.Parameters.Clear();
                pst.Parameters.AddRange(parameters);
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                //pst.ExecuteNonQuery();
                vai = pst.ExecuteReader();
                List<EntidadeDominio> entidades = new List<EntidadeDominio>();
                Fornecedor p;
                Endereco ende;
                while (vai.Read())
                {
                    ende = new Endereco()
                    {
                        ID = Convert.ToInt32(vai["forne_id"]),
                        Bairro = (vai["bairro"].ToString()),
                        Cep = (vai["cep"].ToString()),
                        Cidade =  (vai["cidade"].ToString()),
                        Complemento = (vai["complemento"].ToString().Substring(1)),
                        Logradouro = (vai["logradouro"].ToString()),
                        Numero = (vai["numero"].ToString()),
                        UF = (vai["uf"].ToString()),

                    };
                    p = new Fornecedor()
                    {
                        ID = Convert.ToInt32(vai["forne_id"]),
                        Nome = (vai["fornecedor_nome"].ToString()),
                        CNPJ = (vai["cnpj"].ToString().Trim()),
                        ENDERECO = ende
                        
                    };
                    p.CNPJ = p.CNPJ.Substring(0, 2) + "." + p.CNPJ.Substring(2, 3) + "." + p.CNPJ.Substring(5, 3) + "/" + p.CNPJ.Substring(8, 4) + "-" + p.CNPJ.Substring(12, 2);
                    entidades.Add(p);
                }
                connection.Close();
                return entidades;
            }
            catch (OracleException ora)
            {
                throw ora;
            }


        }
        public override void Excluir(EntidadeDominio entidade)
        {
            connection.Open();
            try
            {

                pst.CommandText = "DELETE FROM " + table + " WHERE " + id_table + "=" + entidade.ID.ToString();
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                pst.ExecuteNonQuery();
                pst.CommandText = "commit work";
                pst.ExecuteNonQuery();
                if (ctrlTransaction)
                    connection.Close();


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
