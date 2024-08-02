
namespace Instagram.Integracao.Models.Contracts
{
    public class RetornoGenericoModel : IRetornoGenericoModel
    {
        public RetornoGenericoModel()
        {
        }

        public RetornoGenericoModel(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }

}