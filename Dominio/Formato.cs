using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Formato : EntidadeDominio
    {
        private int codFormato;
        private decimal altura;
        private decimal largura;
        private decimal diametro;
        private decimal comprimento;
        private string peso;
        private string dimensoes;

        public string Dimensoes
        {
            get { return dimensoes; }
            set { dimensoes = value;}
        }

        public string Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public decimal Comprimento
        {
            get { return comprimento; }
            set { comprimento = value; }
        }

        public decimal Diametro
        {
            get { return diametro; }
            set { diametro = value; }
        }

        public decimal Largura
        {
            get { return largura; }
            set { largura = value; }
        }

        public decimal Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public int CodFormato
        {
            get { return codFormato; }
            set { codFormato = value; }
        }

        public Formato():base()
        {
            codFormato=0;
            altura =0 ;
            largura=0;
            diametro=0;
            comprimento=0;
            peso="";
            dimensoes = "";
        }

        
    }
}
