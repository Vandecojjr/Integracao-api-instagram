using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IComentarioService
    {
        Task<IRetornoGenericoModel> Buscar(CriarBuscaDeComentario model);
    }
}