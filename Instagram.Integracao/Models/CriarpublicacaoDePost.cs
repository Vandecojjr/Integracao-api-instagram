using Flunt.Notifications;
using Flunt.Validations;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarpublicacaoDePost : Notifiable, IModel
    {
        public string Descricao { get; set; }
        public string Media { get; set; }

        public void Validate()
        {

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Media, "Media", "Media deve ser informado")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao deve ser informado")
            );
        }

    }
}