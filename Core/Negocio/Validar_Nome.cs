using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core;
using Dominio;
using System.Text.RegularExpressions;

namespace Core.Negocio
{
    class Validar_Nome : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            Pessoa pe = (Pessoa)entidade;
            sb = new  StringBuilder( null);
            if(pe.Nome.Length<3)
                sb.Append("nome pequeno demais\n");
            if(pe.Nome.Length>40)
                sb.Append("nome excede o limite de caracteres\n");
            foreach (char s in pe.Nome)
            {
                if (char.IsDigit(s))
                {
                        sb.Append("há numeros neste nome\n");
                }


            }
            if (Regex.IsMatch(pe.Nome, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                    sb.Append("há caractere especial no nome\n");

            }
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}
