using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Produto:EntidadeDominio
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public Produto()
        {
            nome = "";
        }

    }
}
