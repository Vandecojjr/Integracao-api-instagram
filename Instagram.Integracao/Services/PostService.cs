
using System.Text.Json;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;
using Instagram.Integracao.Settings;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Instagram.Integracao.Services
{
    public class PostService : IPostService
    {
        private readonly IJsonService _jsonService;
        private readonly IRequisicaoPostService _requisicao;

        public PostService(IJsonService jsonService, IRequisicaoPostService requisicao)
        {
            _jsonService = jsonService;
            _requisicao = requisicao;
        }

        public async Task<IRetornoGenericoModel> Criar(CriarpublicacaoDePost model)
        {
            return await CriarConteinerDePublicacao(model.LinkDaMedia, model.Descricao, model.Video);
        }

        public async Task<IRetornoGenericoModel> CriarConteinerDePublicacao(string mediaLink, string descricao, bool tipoDeMidia)
        {
            var resposta = await _requisicao.ContainerRequisicao(mediaLink, descricao, tipoDeMidia);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            var containerId = await _jsonService.ObterRespostaAsync(resposta, "id");
            return await PublicarPost(containerId);
        }


        public async Task<IRetornoGenericoModel> PublicarPost(string containerId)
        {

            var resposta = await _requisicao.PublicarRequisicao(containerId);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            var idDoPost = await _jsonService.ObterRespostaAsync(resposta, "id");
            object linkDoPost = await Buscar(idDoPost);
            return new RetornoGenericoModel(true, "Post criado com sucesso!", linkDoPost);
        }


        public async Task<object> Buscar(string postId)
        {
            var resposta = await _requisicao.BuscarPostRequisicao(postId);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            return await _jsonService.ObterRespostaAsync(resposta, "permalink");
        }
    }
}