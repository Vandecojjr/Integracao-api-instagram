namespace Instagram.Integracao.Services.Contracts
{
    public interface IRequisicaoMensagem
    {
        Task<HttpResponseMessage> BuscarMensagems(string usuarioId);
    }
}