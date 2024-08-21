using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Services.Contracts
{
    public interface IMensagemService
    {
        Task<IRetornoGenericoModel> Buscar(CriarBuscaDeMensagem model);
        Task<IRetornoGenericoModel> Enviar(CriarpublicacaoDeMensagem model);
    }
}