using Instagram.Integracao.Models;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IRequisicaoMensagem
    {
        Task<HttpResponseMessage> BuscarMensagems(string usuarioId);
        Task<HttpResponseMessage> EnviarMensagem(CriarpublicacaoDeMensagem model);
    }
}