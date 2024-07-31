using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class MensagemHandler :
    Notifiable,
    IHandler<CriarpublicacaoDeMensagem>
    {
        public async Task<IRetornoGenericoModel> Handle(CriarpublicacaoDeMensagem model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return new RetornoGenericoModel(true, "Mensagem criada com sucesso!", model);
        }

    }
}