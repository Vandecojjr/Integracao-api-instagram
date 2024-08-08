using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class BuscarMensagemHandler :
    Notifiable,
    IHandler<CriarBuscaDeMensagem>
    {
        private readonly IMensagemService _mensagemService;

        public BuscarMensagemHandler(IMensagemService mensagemService)
        {
            _mensagemService = mensagemService;
        }

        public async Task<IRetornoGenericoModel> Handle(CriarBuscaDeMensagem model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return await _mensagemService.Buscar(model);
        }

    }
}