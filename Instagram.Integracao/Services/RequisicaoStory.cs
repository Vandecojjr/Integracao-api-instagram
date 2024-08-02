using Instagram.Integracao.Services.Contracts;
using Instagram.Integracao.Settings;
using Microsoft.Extensions.Options;

namespace Instagram.Integracao.Services
{
    public class RequisicaoStory : IRequisicaoStory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _cliente;
        private readonly GraphApi _ApiSettings;

        public RequisicaoStory(IHttpClientFactory clientFactory, HttpClient cliente, IOptions<GraphApi> apiSettings)
        {
            _clientFactory = clientFactory;
            _cliente = _clientFactory.CreateClient("Instagram");
            _ApiSettings = apiSettings.Value;
        }
        public Task<HttpResponseMessage> ContainerRequisicao(string mediaLink, bool tipoDeMidia)
        {
            var media = $"image_url={mediaLink}";
            if (tipoDeMidia)
                media = $"video_url={mediaLink}";

            var url = $"{_ApiSettings.UserId}/media?" +
               $"{media}" +
               $"&media_type=STORIES" +
               $"&access_token={_ApiSettings.Token}";

            return _cliente.PostAsync(url, null);
        }

        public Task<HttpResponseMessage> PublicarRequisicao(string containerId)
        {
            var url = $"{_ApiSettings.UserId}/media_publish?" +
                $"creation_id={containerId}" +
                $"&access_token={_ApiSettings.Token}";

            return _cliente.PostAsync(url, null);
        }

    }
}