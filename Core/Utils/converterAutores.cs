using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Core.Utils
{
    public class ConverterAutores
    {
        public List<Autor> Processar(string txt)
        {
            List<Autor> la = new List<Autor>();
            Autor aa;
            foreach (string a in txt.Split(','))
            {
                aa = new Autor()
                {
                    ID = 0,
                    Nome = a
                };
                la.Add(aa);
            }
            return la;
        }
    }
}
