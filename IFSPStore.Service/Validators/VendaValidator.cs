using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator() 
        {
            // Valida o campo Data
            RuleFor(v => v.Data)
                .NotEmpty().WithMessage("A data da venda é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da venda não pode ser uma data futura.");

            // Valida o campo ValorTotal
            RuleFor(v => v.ValorTotal)
                .GreaterThan(0).WithMessage("O valor total da venda deve ser maior que zero.");

            // Valida o campo IdCliente (campo obrigatório)
            RuleFor(v => v.Cliente)
                .NotEmpty().WithMessage("O cliente da venda é obrigatório.");
        }
    }
}
