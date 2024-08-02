using Instagram.Integracao.Services.Contracts;
using Instagram.Integracao.Settings;
using Microsoft.Extensions.Options;

namespace Instagram.Integracao.Services
{
    public class RequisicaoComentario : IRequisicaoComentario
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _cliente;
        private readonly GraphApi _ApiSettings;

        public RequisicaoComentario(IHttpClientFactory clientFactory, HttpClient cliente, IOptions<GraphApi> apiSettings)
        {
            _clientFactory = clientFactory;
            _cliente = _clientFactory.CreateClient("Instagram");
            _ApiSettings = apiSettings.Value;
        }
        public Task<HttpResponseMessage> BuscarComentarios(string postId)
        {
            var url = $"{postId}/comments?" +
                $"fields=from,text,media,timestamp" +
                $"&access_token={_ApiSettings.Token}";

            return _cliente.GetAsync(url);
        }
    }
}