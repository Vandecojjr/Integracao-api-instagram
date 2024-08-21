using Flunt.Validations;
using Flunt.Notifications;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarpublicacaoDeMensagem : Notifiable, IModel
    {
        public string IdDoUsuario { get; set; }
        public string Texto { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(IdDoUsuario, "IdDoUsuario", "IdDoUsuario deve ser informado")
                .IsNotNullOrEmpty(Texto, "Texto", "Texto deve ser informado")
            );
        }
    }
}