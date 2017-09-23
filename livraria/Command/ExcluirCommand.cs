using Core.Aplicacao;
using Dominio;

namespace livraria.Command
{
    public class ExcluirCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Excluir(entidade);
        }
    }
}