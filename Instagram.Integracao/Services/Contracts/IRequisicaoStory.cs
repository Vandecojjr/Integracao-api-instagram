namespace Instagram.Integracao.Services.Contracts
{
    public interface IRequisicaoStory
    {
        Task<HttpResponseMessage> ContainerRequisicao(string mediaLink, bool tipoDeMidia);
        Task<HttpResponseMessage> PublicarRequisicao(string containerId);
    }
}