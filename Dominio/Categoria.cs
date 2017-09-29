using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria:EntidadeDominio
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private List<Sub_Categoria> sub_Categorias;

        public List<Sub_Categoria> Sub_Categorias
        {
            get { return sub_Categorias; }
            set { sub_Categorias = value; }
        }

        public Categoria()
        {
            nome = "";
            sub_Categorias = new List<Sub_Categoria>();
        }
    }
}
