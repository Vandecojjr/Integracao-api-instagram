using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class StoryHandler :
    Notifiable,
    IHandler<CriarpublicacaoDeStory>
    {
        public async Task<IRetornoGenericoModel> Handle(CriarpublicacaoDeStory model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return new RetornoGenericoModel(true, "Story criado com sucesso!", model);
        }
    }
}