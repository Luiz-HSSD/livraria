using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Core.DAO;

namespace Core.Negocio
{
    class Controle_Autor : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            try
            {
                Livro liv = (Livro)entidade;
                AutorDAO forn = new AutorDAO();
                for (int i = 0;i<liv.Autores.Count ;i++ )
                {
                    Autor endereco = liv.Autores[i];
                    List<EntidadeDominio> ende = forn.Consultar(endereco);
                    if (ende.Count > 0)
                        liv.Autores[i] = (Autor)ende.ElementAt(0);
                    else
                    {
                        forn.Salvar(liv.Autores[i]);
                        ende = forn.Consultar(liv.Autores[i]);
                        liv.Autores[i] = (Autor)ende.ElementAt(0);
                    }
                }
                return null;
            }
            catch (Exception e) {
                return e.Message;
            }
        }
    }
}
