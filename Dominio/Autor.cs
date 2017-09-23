using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Autor:Pessoa_Fisica
    {
        private List<Livro> autoria;

        public List<Livro> Autoria
        {
            get { return autoria; }
            set { autoria = value; }
        }

        public Autor()
        {
            autoria = new List<Livro>();
        }
        
    }
}
