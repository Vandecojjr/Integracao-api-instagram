using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Services
{
    public class MensagemService : IMensagemService
    {
        private readonly IJsonService _jsonService;
        private readonly IRequisicaoMensagem _requisicao;

        public MensagemService(IJsonService jsonService, IRequisicaoMensagem requisicao)
        {
            _jsonService = jsonService;
            _requisicao = requisicao;
        }
        public async Task<IRetornoGenericoModel> Buscar(CriarBuscaDeMensagem model)
        {
            var resposta = await _requisicao.BuscarMensagems(model.idDoUsuario);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            return new RetornoGenericoModel(true, "Comentarios recuperados com sucesso!", conteudo);

        }

    }
}