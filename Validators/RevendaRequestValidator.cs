using CpfCnpjLibrary;
using FluentValidation;
using PedidoBebidaAPI.DTOs;

namespace PedidoBebidaAPI.Validators
{
    public class RevendaRequestValidator : AbstractValidator<RevendaRequest>
    {
        public RevendaRequestValidator()
        {
            RuleFor(r => r.Cnpj)
           .NotEmpty().WithMessage("CNPJ é obrigatório!")
           .Must(c => Cnpj.Validar(c)).WithMessage("CNPJ inválido!");

            RuleFor(r => r.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social é obrigatória!");

            RuleFor(r => r.NomeFantasia)
                .NotEmpty().WithMessage("Nome Fantasia é obrigatória!");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório!")
                .EmailAddress().WithMessage("E-mail inválido!");

            RuleFor(r => r.Contatos)
                .NotNull().WithMessage("É necessário informar ao menos um contato!")
                .Must(c => c.Any(x => x.Principal)).WithMessage("Deve ter pelo menos um contato principal!");

            RuleFor(r => r.EnderecosEntrega)
                .NotNull().WithMessage("É necessário informar ao menos um endereço!")
                .Must(e => e.Any()).WithMessage("É necessário ter pelo menos um endereço de entrega!");
        }
    }
}

