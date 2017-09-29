using System;
using System.Collections.Generic;
using Dominio;
using Oracle.DataAccess.Client;
using System.Data;

namespace Core.DAO
{
    class LivroDAO : AbstractDAO
    {
        public LivroDAO() : base("livro", "livro_id")
        {
        }

        public override void Salvar(EntidadeDominio entidade)
        {
            connection.Open();
            Livro liv = (Livro)entidade;
            pst.CommandText = "insert into livro ( ativo, ano, isbn, nome, n_pags, descricao, id_for , editora ) values ( 'A' , :ano , :isb , :nome , :n_pags, :des , :forma , :editor)";
            parameters = new OracleParameter[]
                    {

                        new OracleParameter("ano",liv.Ano),
                        new OracleParameter("isb",liv.ISBN),
                        new OracleParameter("nome",liv.Nome),
                        new OracleParameter("n_pags",liv.N_Pags),
                        new OracleParameter("des",liv.Descricao),
                        new OracleParameter("forma",liv.Formato.ID),
                        new OracleParameter("editor",liv.Editora)
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
                Livro liv = (Livro)entidade;
                pst.CommandText = "UPDATE livro SET ano=:ano,  isbn=:isb, nome=:nome, n_pags=:n_pags, descricao=:des, id_for=:forma, editora=:editora  WHERE livro_id=:co";
                parameters = new OracleParameter[]
                    {
                        new OracleParameter("ano",liv.Ano),
                        new OracleParameter("isb",liv.ISBN),
                        new OracleParameter("nome",liv.Nome),
                        new OracleParameter("n_pags",liv.N_Pags),
                        new OracleParameter("des",liv.Descricao),
                        new OracleParameter("forma",liv.Formato.ID),
                        new OracleParameter("editora",liv.Editora)
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
                Livro liv = (Livro)entidade;
                string sql = null;

                if (liv.Nome == null)
                {
                    liv.Nome = "";
                }

                if (liv.ISBN == null)
                {
                    liv.ISBN = "";
                }
                if (liv.Descricao == null)
                {
                    liv.Descricao = "";
                }

                if (liv.ID == 0)
                {
                    sql = "SELECT * FROM livro left join sub_cat_livro using(livro_id) left join sub_categoria using(sub_cat_id) left join livro_autor using(livro_id) left join autor using(autor_id)";
                }
                else
                {
                    sql = "SELECT * FROM livro left join sub_cat_livro using(livro_id) left join sub_categoria using(sub_cat_id) left join livro_autor using(livro_id) left join autor using(autor_id) WHERE forne_id= :co";
                }
                pst.CommandText = sql;
                parameters = new OracleParameter[] { new OracleParameter("co", liv.ID.ToString()) };
                pst.Parameters.Clear();
                pst.Parameters.AddRange(parameters);
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                //pst.ExecuteNonQuery();
                vai = pst.ExecuteReader();
                List<EntidadeDominio> entidades = new List<EntidadeDominio>();
                Livro p;
                Sub_Categoria sub;
                Autor aut;
                Livro last= new Livro() { ID=0};
                while (vai.Read())
                {
                    sub = new Sub_Categoria()
                    {
                        
                    };
                    if (vai["sub_cat_id"] != DBNull.Value) { 
                        sub.ID = Convert.ToInt32(vai["sub_cat_id"]);
                        sub.Nome = vai["nome_sub_cat"].ToString();
                        sub.Ativo = Convert.ToChar(vai["ativo_sub_cat"]);
                    }
                    aut = new Autor()
                    {
                        
                    };
                    if (vai["autor_id"] != DBNull.Value)
                    {
                        aut.ID = Convert.ToInt32(vai["autor_id"]);
                        aut.Nome = vai["nome_aut"].ToString();
                        aut.Ativo = Convert.ToChar(vai["ativo_aut"]);
                    }
                    p = new Livro()
                    {
                        ID = Convert.ToInt32(vai["livro_id"]),
                        Nome = (vai["nome"].ToString()),
                        ISBN = (vai["isbn"].ToString()),
                        N_Pags = Convert.ToInt32(vai["n_pags"]),
                        Ano = Convert.ToInt32(vai["ano"]),
                        Descricao = (vai["descricao"].ToString()),
                        Editora = vai["editora"].ToString()
                        
                    };
                    if (p.ID == last.ID)
                    {
                        last.Sub_categorias.Add(sub);
                        last.Autores.Add(aut);
                    }
                    else
                    {
                        entidades.Add(p);
                        last = p;
                    }
                }
                connection.Close();
                return entidades;
            }
            catch (OracleException ora)
            {
                throw ora;
            }
        }


    }
}
