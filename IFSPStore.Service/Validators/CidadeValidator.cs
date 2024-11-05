using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor informe o nome");
            RuleFor(c => c.Estado)
               .NotEmpty().WithMessage("Por favor informe o Estado.")
               .NotNull().WithMessage("Por favor informe o Estado");
        }
    }
}
