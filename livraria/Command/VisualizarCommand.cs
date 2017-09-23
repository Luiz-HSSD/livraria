using Core.Aplicacao;
using Dominio;

namespace livraria.Command
{
    public class VisualizarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Visualizar(entidade);
        }
    }
}