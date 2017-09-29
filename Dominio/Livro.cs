using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Livro:Produto
    {
        private string isbn;

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        private int n_pags;

        public int N_Pags
        {
            get { return n_pags; }
            set { n_pags = value; }
        }


        private List<Autor> autores;

        public List<Autor> Autores
        {
            get { return autores; }
            set { autores = value; }
        }
        private int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private int qtd;

        public int Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }

        private double preco_medio_compra;

        public double Preco_Medio_Compra
        {
            get { return preco_medio_compra; }
            set { preco_medio_compra = value; }
        }
        private List<Sub_Categoria> sub_categorias; 

        public List<Sub_Categoria> Sub_categorias
        {
            get { return sub_categorias; }
            set { sub_categorias = value; }
        }
        private string editora;

        public string Editora
        {
            get { return editora; }
            set { editora = value; }
        }



        public Livro()
        {
            isbn = "";
            n_pags = 0;
            autores = new List<Autor>();
            sub_categorias = new List<Sub_Categoria>();
            ano = 0;
            descricao = "";
            qtd = 0;
            preco_medio_compra = 0;
            editora = "";    
        }
    }
}
