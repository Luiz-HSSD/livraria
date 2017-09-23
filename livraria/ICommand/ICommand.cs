using Core.Aplicacao;
using Dominio;
namespace livraria.ICommand
{
    public interface ICommand
    {
         Resultado Execute(EntidadeDominio entidade) ;
    }
}
