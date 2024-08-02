using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class StoryHandler :
    Notifiable,
    IHandler<CriarpublicacaoDeStory>
    {
        private readonly IStoryService _storyService;

        public StoryHandler(IStoryService storyService)
        {
            _storyService = storyService;
        }
        public async Task<IRetornoGenericoModel> Handle(CriarpublicacaoDeStory model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return await _storyService.Criar(model);
        }
    }
}