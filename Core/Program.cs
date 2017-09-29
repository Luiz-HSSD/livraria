using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DAO;
using Dominio;
using Core.Controle;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Formato formato = new Formato()
            {
                ID = 1 
            };
            Livro livro = new Livro()
            {
                ID=0,
                Nome="IT a coisa",
                ISBN="0123456789",
                N_Pags=300,
                Ano=2011,
                Descricao="asdfasdfasdfasdfasdf",
                Formato=formato

            };
            Fachada liv = Fachada.UniqueInstance;
            //FormatoDAO liv = new FormatoDAO();
            liv.Salvar(livro);
            Console.WriteLine(liv.Consultar(livro).Entidades.ElementAt(0).ID);
            Console.ReadLine();
        }
    }
}