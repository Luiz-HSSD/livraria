using Core.Aplicacao;
using Dominio;
namespace livraria.Command
{
    public class AlterarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Alterar(entidade);
        }
    }
}