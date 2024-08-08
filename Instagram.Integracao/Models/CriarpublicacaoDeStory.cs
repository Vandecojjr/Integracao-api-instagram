using Flunt.Notifications;
using Flunt.Validations;
using Instagram.Integracao.Models.Contracts;

namespace Instagram.Integracao.Models
{
    public class CriarpublicacaoDeStory : Notifiable, IModel
    {
        public string LinkDaMedia { get; set; }
        public bool Video { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(LinkDaMedia, "Media", "Media deve ser informado")
            );
        }

    }
}