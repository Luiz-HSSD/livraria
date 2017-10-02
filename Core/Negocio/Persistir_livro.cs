using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Core.DAO;

namespace Core.Negocio
{
    class Persistir_livro : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            AutorDAO Adao = new AutorDAO();

            LivroDAO lDAO = new LivroDAO();
            throw new NotImplementedException();
        }
    }
}
