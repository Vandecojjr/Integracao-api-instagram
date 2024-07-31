using System.Text.Json;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Services
{
    public class JsonService : IJsonService
    {
        public async Task<string> ObterRespostaAsync(HttpResponseMessage resposta, string id)
        {
            var conteudo = await resposta.Content.ReadAsStringAsync();
            using var jsonDocumento = JsonDocument.Parse(conteudo);
            return jsonDocumento.RootElement.GetProperty(id).ToString();

        }

        public async Task<object> ObterRespostaAsync(HttpResponseMessage resposta)
        {
            var conteudo = await resposta.Content.ReadAsStringAsync();
            using var jsonDocumento = JsonDocument.Parse(conteudo);
            return jsonDocumento.RootElement.Clone();
        }
    }
}