using System.Text;
using Instagram.Integracao.Models;
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

        public async Task<HttpResponseMessage> EnviarMensagem(CriarpublicacaoDeMensagem model)
        {
            var url = $"/{_ApiSettings.UserId}/messages";

            var requestBody = new
            {
                recipient = new { id = model.IdDoUsuario },
                message = new { text = model.Texto }
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"Bearer {_ApiSettings.Token}");
            request.Content = content;

            var resposta = await _cliente.SendAsync(request);
            return resposta;
        }
    }
}