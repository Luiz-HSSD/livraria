using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class Pessoa_Fisica:Pessoa
    {
        private int idade;

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public Pessoa_Fisica()
        {
            idade = 0;
        }
    }
}
