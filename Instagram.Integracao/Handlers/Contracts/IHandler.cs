using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Handlers.Contracts
{
    public interface IHandler<T> where T : IModel
    {
        Task<IRetornoGenericoModel> Handle(T model);
    }
}