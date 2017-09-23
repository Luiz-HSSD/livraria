using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Core.Negocio
{
    class Validar_Endereco : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            Endereco end = (Endereco)entidade;
            sb = new StringBuilder(null);
            if (String.IsNullOrEmpty(end.UF))
                sb.Append("UF não pode estar vazia");
            if (String.IsNullOrEmpty(sb.ToString()))
            {
                if (String.IsNullOrEmpty(end.Logradouro))
                    sb.Append("\nLogradouro não pode estar vazia");
            }
            else if (String.IsNullOrEmpty(end.Cidade))
                sb.Append("\nLogradouro não pode estar vazia");

            return sb.ToString();
        }
    }
}
