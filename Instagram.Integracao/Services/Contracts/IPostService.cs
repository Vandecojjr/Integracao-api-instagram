using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IPostService
    {
        Task<IRetornoGenericoModel> Criar(CriarpublicacaoDePost model);
        Task<object> Buscar(string postId);
    }
}