using Instagram.Integracao.Services.Contracts;
using Instagram.Integracao.Settings;
using Microsoft.Extensions.Options;

namespace Instagram.Integracao.Services
{
    public class RequisicaoMensagem : IRequisicaoMensagem
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _cliente;
        private readonly GraphApi _ApiSettings;

        public RequisicaoMensagem(IHttpClientFactory clientFactory, HttpClient cliente, IOptions<GraphApi> apiSettings)
        {
            _clientFactory = clientFactory;
            _cliente = _clientFactory.CreateClient("Instagram");
            _ApiSettings = apiSettings.Value;
        }
        public Task<HttpResponseMessage> BuscarMensagems(string usuarioId)
        {
            var url = $"/conversations" +
                $"?user_id={usuarioId}" +
                $"&fields=id,created_time,from,to,message" +
                $"&access_token={_ApiSettings.Token}";

            return _cliente.GetAsync(url);
        }

    }
}