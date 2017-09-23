using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Core.Core
{
    public interface IDAO
    {
         void Salvar(EntidadeDominio entidade);
         void Alterar(EntidadeDominio entidade);
         void Excluir(EntidadeDominio entidade);
         List<EntidadeDominio> Consultar(EntidadeDominio entidade);

    }
}
