namespace Instagram.Integracao.Services.Contracts
{
    public interface IRequisicaoComentario
    {
        Task<HttpResponseMessage> BuscarComentarios(string postId);
    }
}