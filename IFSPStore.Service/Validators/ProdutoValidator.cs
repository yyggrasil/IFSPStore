using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    internal class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {

            // Valida o campo Nome
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do produto não pode exceder 100 caracteres.");

            // Valida o campo Preço
            RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.")
                .ScalePrecision(2, 10).WithMessage("O preço do produto deve ter até 10 dígitos com 2 casas decimais.");

            // Valida o campo Quantidade
            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade do produto não pode ser negativa.");

            // Valida o campo DataCompra
            RuleFor(p => p.DataCompra)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data de compra não pode ser uma data futura.")
                .When(p => p.DataCompra.HasValue);

            // Valida o campo UnidadeVenda
            RuleFor(p => p.UnidadeVenda)
                .NotEmpty().WithMessage("A unidade de venda é obrigatória.")
                .MaximumLength(10).WithMessage("A unidade de venda não pode exceder 10 caracteres.");

            // Valida o campo IdGrupo (campo obrigatório)
            RuleFor(p => p.Grupo)
                .NotEmpty().WithMessage("O grupo do produto é obrigatório.");
        }
    }
}
