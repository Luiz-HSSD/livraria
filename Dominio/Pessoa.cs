using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pessoa:EntidadeDominio
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private Endereco endereco;

        public Endereco ENDERECO
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public Pessoa():base()
        {
            nome = "";
            endereco = new Endereco();
        }
    }
}
