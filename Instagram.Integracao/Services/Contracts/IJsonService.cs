using System.Runtime.Serialization;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IJsonService
    {
        Task<string> ObterRespostaAsync(HttpResponseMessage resposta, string id);
        Task<object> ObterRespostaAsync(HttpResponseMessage resposta);
    }
}