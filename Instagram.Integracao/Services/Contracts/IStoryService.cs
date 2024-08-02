using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IStoryService
    {
        Task<IRetornoGenericoModel> Criar(CriarpublicacaoDeStory model);
    }
}