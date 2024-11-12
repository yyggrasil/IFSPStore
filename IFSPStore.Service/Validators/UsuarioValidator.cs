using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    internal class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            // Valida o campo Nome
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do usuário não pode exceder 100 caracteres.");

            // Valida o campo Login
            RuleFor(u => u.Login)
                .MaximumLength(25).WithMessage("A senha não pode ter mais de 25 caracteres")
                .Matches(@"[A-Z]+").WithMessage("A senha deve conter uma letra maiúscula")
                .Matches(@"[a-z]+").WithMessage("A senha deve conter uma letra minúscula")
                .Matches(@"[0-9]+").WithMessage("A senha deve conter um número")
                .Matches(@"[\!\@\#\$\%\¨\'\&\*\(\)\-\_\+\=\/\\\?\°\~\|\^\]\[\}\{\º\ª]+").WithMessage("A senha deve conter um caracter especial")
                .MaximumLength(45).WithMessage("O login do usuário não pode exceder 45 caracteres.");

            // Valida o campo Senha
            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .MinimumLength(8).WithMessage("A senha do usuário deve ter pelo menos 8 caracteres.")
                .MaximumLength(45).WithMessage("A senha do usuário não pode exceder 45 caracteres.")
                ;

            // Valida o campo DataCadastro
            RuleFor(u => u.DataCadastro)
                .NotEmpty().WithMessage("A data de cadastro é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de cadastro não pode ser no futuro.");

            // Valida o campo DataLogin (opcional)
            RuleFor(u => u.DataLogin)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de login não pode ser no futuro.")
                .When(u => u.DataLogin.HasValue);

            // Valida o campo Ativo
            RuleFor(u => u.Ativo)
                .NotNull().WithMessage("O status ativo do usuário é obrigatório.");
        }
    }
}
