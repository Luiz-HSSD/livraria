using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class EntidadeDominio:IEntidade
    {
        private char ativo;

        public char Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }


        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        public EntidadeDominio()
        {
            id = 0;
            ativo = 'A';
        }
    }
}
