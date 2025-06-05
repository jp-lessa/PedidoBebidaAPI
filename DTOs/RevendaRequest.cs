namespace PedidoBebidaAPI.DTOs
{
    public class RevendaRequest
    {
        public string Cnpj { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string>? Telefones { get; set; }
        public List<ContatoRequest>? Contatos { get; set; }
        public List<EnderecoRequest>? EnderecosEntrega { get; set; }
    }
}
