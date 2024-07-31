using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class PostHandler :
        Notifiable,
        IHandler<CriarpublicacaoDePost>
    {
        private readonly IPostService _postService;

        public PostHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IRetornoGenericoModel> Handle(CriarpublicacaoDePost model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return await _postService.Criar(model);
        }
    }
}