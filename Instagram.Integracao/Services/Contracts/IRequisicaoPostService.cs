namespace Instagram.Integracao.Services.Contracts
{
    public interface IRequisicaoPostService
    {
        Task<HttpResponseMessage> ContainerRequisicao(string mediaLink, string descricao, bool tipoDeMidia);
        Task<HttpResponseMessage> PublicarRequisicao(string containerId);
        Task<HttpResponseMessage> BuscarPostRequisicao(string postId);
    }
}