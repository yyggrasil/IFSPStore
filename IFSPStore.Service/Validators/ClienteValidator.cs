using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor informe o nome");
            RuleFor(c => c.Bairro)
               .NotEmpty().WithMessage("Por favor informe o Bairro.")
               .NotNull().WithMessage("Por favor informe o Bairro");
            RuleFor(c => c.Endereco)
               .NotEmpty().WithMessage("Por favor informe o Endereco.")
               .NotNull().WithMessage("Por favor informe o Endereco");
            RuleFor(c => c.Cidade)
               .NotEmpty().WithMessage("Por favor informe o Cidade.")
               .NotNull().WithMessage("Por favor informe o Cidade");

        }
    }
}
