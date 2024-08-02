using Flunt.Notifications;
using Flunt.Validations;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarpublicacaoDeStory : Notifiable, IModel
    {
        public string Media { get; set; }
        public bool TipoVideo { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Media, "Media", "Media deve ser informado")
            );
        }

    }
}