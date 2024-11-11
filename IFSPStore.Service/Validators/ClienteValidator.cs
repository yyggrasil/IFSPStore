using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            // Valida o campo Nome
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cliente não pode exceder 100 caracteres.");

            // Valida o campo Endereco
            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("O endereço do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O endereço do cliente não pode exceder 100 caracteres.");

            // Valida o campo Documento
            RuleFor(c => c.Documento)
                .NotEmpty().WithMessage("O documento do cliente é obrigatório.")
                .MaximumLength(45).WithMessage("O documento do cliente não pode exceder 45 caracteres.");

            // Valida o campo Bairro
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O bairro do cliente é obrigatório.")
                .MaximumLength(45).WithMessage("O bairro do cliente não pode exceder 45 caracteres.");

            // Valida o campo Cidade
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A cidade do cliente é obrigatória.");

            // Valida o campo IdCidade (campo obrigatório)
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A cidade do cliente é obrigatória.");
        }
    }
}
