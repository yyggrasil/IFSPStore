using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    internal class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informar nome.")
                .NotNull().WithMessage("Por favor informar nome.");
            RuleFor(c => c.Preco)
                .NotEmpty().WithMessage("Por favor informar preço")
                .NotNull().WithMessage("Por favor informar preço");
        }
    }
}
