using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Core.Negocio
{
    class Validar_Livro : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            Livro liv = (Livro)entidade;
            sb = new StringBuilder(null);
            if (String.IsNullOrEmpty(liv.Nome))
                sb.Append("O nome do livro não pode ser vazio\n");
            if (liv.Nome.Length < 4)
                sb.Append("O nome do livro não pode ter menos de 4 caracteres\n");
            if (liv.Nome.Length > 60)
                sb.Append("O nome do livro não pode ter mais de 60 caracteres\n");
            liv.ISBN = liv.ISBN.Replace(".", "");
            liv.ISBN = liv.ISBN.Replace("-", "");
            liv.ISBN = liv.ISBN.Replace("/", "");
            liv.ISBN = liv.ISBN.Replace("ISBN ", "");
            liv.ISBN = liv.ISBN.Replace("ISBN", "");
            if (liv.ISBN.Length!=10)
                sb.Append("ISBN formato incorreto\n");
            if(!(liv.N_Pags>0 && liv.N_Pags<99999))
                sb.Append("Número de páginas inválido\n");
            if (liv.Descricao.Length <= 15)
                sb.Append("Descrição muito pequena\n");
            if (String.IsNullOrEmpty(sb.ToString()))
                return null;
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}
