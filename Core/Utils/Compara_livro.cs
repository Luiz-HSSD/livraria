using Dominio;

namespace Core.Utils
{
    public class Compara_livro
    {
        public static bool Comparar(Livro liv1, Livro liv2)
        {
            if(liv1.ID== liv2.ID)
            return true;
            return false;
        }
    }
}
