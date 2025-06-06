using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Models;
using PedidoBebidaAPI.Repositories;

namespace PedidoBebidaAPI.Services
{
    public class RevendaService
    {
        private readonly IRevendaRepository _revendaRepository;

        public RevendaService(IRevendaRepository revendaRepository)
        {
            _revendaRepository = revendaRepository;
        }

        public void Cadastrar(RevendaRequest request)
        {
            var revenda = new Revenda
            {
                Cnpj = request.Cnpj,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Email = request.Email,
                Telefones = request.Telefones ?? new List<string>(),
                Contatos = CadastrarContatos(request.Contatos),
                EnderecosEntrega = CadastrarEnderecos(request.EnderecosEntrega)
            };

            _revendaRepository.Adicionar(revenda);
        }

        public IEnumerable<Revenda> Listar()
        {
            return _revendaRepository.ObterTodas();
        }

        private List<EnderecoRevenda> CadastrarEnderecos(List<EnderecoRequest>? enderecosEntrega)
        {
            if (enderecosEntrega is null || enderecosEntrega.Count == 0)
                return new List<EnderecoRevenda>();

            return enderecosEntrega.Select(e => new EnderecoRevenda
            {
                Rua = e.Rua,
                Numero = e.Numero,
                Cidade = e.Cidade,
                Estado = e.Estado,
                Cep = e.Cep
            }).ToList();
        }

        private List<ContatoRevenda> CadastrarContatos(List<ContatoRequest>? contatos)
        {
            if (contatos is null || contatos.Count == 0)
                return new List<ContatoRevenda>();

            return contatos.Select(c => new ContatoRevenda
            {
                Nome = c.Nome,
                Principal = c.Principal
            }).ToList();
        }
    }
}
