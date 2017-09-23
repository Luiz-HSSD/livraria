using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;
using Core.Core;
using Core.Utils;
using Dominio;
using System.Data.SqlClient;
using System.Text;

namespace Core.DAO
{
    public abstract class AbstractDAO:IDAO
    {
        protected OracleDataReader vai;
        protected OracleConnection connection=Conexao.getConnection();
        protected string table;
        protected string id_table;
        protected bool ctrlTransaction = true;
        protected OracleCommand pst = new OracleCommand();
        protected OracleParameter[] parameters;
        

        protected AbstractDAO(string table, string id_table)
        {
            this.table = table;
            this.id_table = id_table;
        }


        //private DataSet vai;

        public abstract void Salvar(EntidadeDominio entidade);


        public abstract void Alterar(EntidadeDominio entidade);


        public abstract List<EntidadeDominio> Consultar(EntidadeDominio entidade);

        public virtual void Excluir(EntidadeDominio entidade)
        {
            connection.Open();
            try
            {

                pst.CommandText = "UPDATE "+table+ "SET ativo='I'  WHERE "+id_table+"="+entidade.ID.ToString() ;
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
        protected void OpenConnection()
        {
            try
            {

                if (connection == null )
                    connection = Conexao.getConnection();
            }
            catch 
            {

            }
        }
    }
    }
