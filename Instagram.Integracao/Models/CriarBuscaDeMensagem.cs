using Flunt.Notifications;
using Flunt.Validations;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarBuscaDeMensagem : Notifiable, IModel
    {
        public string idDoUsuario { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(idDoUsuario, "idDoUsuario", "Id do Usuario deve ser informado")
            );
        }

    }
}