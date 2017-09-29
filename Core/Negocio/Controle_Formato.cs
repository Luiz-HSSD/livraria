using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Core.DAO;

namespace Core.Negocio
{
    class Controle_Formato : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            try
            {
                Livro liv = (Livro)entidade;
                Formato endereco = liv.Formato;
                FormatoDAO forn = new FormatoDAO();
                List<EntidadeDominio> ende = forn.Consultar(endereco);
                if (ende.Count > 0)
                    liv.Formato = (Formato)ende.ElementAt(0);
                else
                {
                    forn.Salvar(liv.Formato);
                    ende = forn.Consultar(liv.Formato);
                    liv.Formato = (Formato)ende.ElementAt(0);
                }
                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
            
        }
    }
}
