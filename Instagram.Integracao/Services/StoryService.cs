using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Services
{
    public class StoryService : IStoryService
    {
        private readonly IJsonService _jsonService;
        private readonly IRequisicaoStory _requisicao;

        public StoryService(IJsonService jsonService, IRequisicaoStory requisicao)
        {
            _jsonService = jsonService;
            _requisicao = requisicao;
        }
        public async Task<IRetornoGenericoModel> Criar(CriarpublicacaoDeStory model)
        {
            return await CriarConteinerDePublicacao(model.Media, model.TipoVideo);
        }

        public async Task<IRetornoGenericoModel> CriarConteinerDePublicacao(string mediaLink, bool tipoDeMidia)
        {
            var resposta = await _requisicao.ContainerRequisicao(mediaLink, tipoDeMidia);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            var containerId = await _jsonService.ObterRespostaAsync(resposta, "id");
            return await PublicarStory(containerId);
        }

        public async Task<IRetornoGenericoModel> PublicarStory(string containerId)
        {
            var resposta = await _requisicao.PublicarRequisicao(containerId);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            return new RetornoGenericoModel(true, "Story criado com sucesso!", conteudo);
        }
    }
}