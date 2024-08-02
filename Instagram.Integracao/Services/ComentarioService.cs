using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IJsonService _jsonService;
        private readonly IRequisicaoComentario _requisicao;

        public ComentarioService(IJsonService jsonService, IRequisicaoComentario requisicao)
        {
            _jsonService = jsonService;
            _requisicao = requisicao;
        }
        public async Task<IRetornoGenericoModel> Buscar(CriarBuscaDeComentario model)
        {
            var resposta = await _requisicao.BuscarComentarios(model.idDoPost);
            var conteudo = await _jsonService.ObterRespostaAsync(resposta);

            if (!resposta.IsSuccessStatusCode)
                return new RetornoGenericoModel(false, "Algo deu errado!", conteudo);

            return new RetornoGenericoModel(true, "Comentarios recuperados com sucesso!", conteudo);

        }

    }
}