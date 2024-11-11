using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() {

            // Valida o campo Nome
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da cidade é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da cidade não pode exceder 100 caracteres.");

            // Valida o campo Estado
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O estado da cidade é obrigatório.")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado deve ser representado por duas letras maiúsculas (ex: SP, RJ).")
                .MaximumLength(2).WithMessage("O estado da cidade deve ter no máximo 2 caracteres.");
        }
    }
}
