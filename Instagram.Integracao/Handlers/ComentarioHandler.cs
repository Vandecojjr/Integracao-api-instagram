using Flunt.Notifications;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services.Contracts;

namespace Instagram.Integracao.Handlers
{
    public class ComentarioHandler :
        Notifiable,
        IHandler<CriarBuscaDeComentario>
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioHandler(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        public async Task<IRetornoGenericoModel> Handle(CriarBuscaDeComentario model)
        {
            model.Validate();
            if (model.Invalid)
                return new RetornoGenericoModel(false, "Algo deu errado!", model.Notifications);

            return await _comentarioService.Buscar(model);
        }
    }
}