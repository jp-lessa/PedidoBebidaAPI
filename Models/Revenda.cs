namespace PedidoBebidaAPI.Models
{
    public class Revenda
    {
        public string Cnpj { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Telefones { get; set; } = new();
        public List<ContatoRevenda> Contatos { get; set; } = new();
        public List<EnderecoRevenda> EnderecosEntrega { get; set; } = new();
    }
}
