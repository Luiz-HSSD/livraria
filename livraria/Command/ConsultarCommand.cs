using Dominio;
using Core.Aplicacao;

namespace livraria.Command
{
    public class ConsultarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Consultar(entidade);
        }
    }
}