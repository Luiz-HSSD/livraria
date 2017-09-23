using Core.Aplicacao;
using Dominio;

namespace livraria.Command
{
    public class SalvarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Salvar(entidade);
        }
    }
}