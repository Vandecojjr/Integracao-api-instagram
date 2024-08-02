using Flunt.Notifications;
using Flunt.Validations;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarBuscaDeComentario : Notifiable, IModel
    {
        public string idDoPost { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(idDoPost, "idDoPost", "Id do post deve ser informado")
            );
        }

    }
}