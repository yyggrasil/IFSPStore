using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator() 
        {
            // Valida o campo Nome
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do usuário não pode exceder 100 caracteres.");

            // Valida o campo Login
            RuleFor(u => u.Login)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .MinimumLength(8).WithMessage("A senha do usuário deve ter pelo menos 8 caracteres.")
                .MaximumLength(45).WithMessage("A senha do usuário não pode exceder 45 caracteres.");

            // Valida o campo Senha
            RuleFor(u => u.Senha)
                .MinimumLength(8).WithMessage("Sua senha tem q ter no minimo 8 caracteres.")
                .MaximumLength(16).WithMessage("Sua senha tem q ter no maximo 16 caracteres.")
                .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter no minimo uma letra maiuscula.")
                .Matches(@"[a-z]+").WithMessage("Sua senha deve conter no minimo uma letra minuscula.")
                .Matches(@"[0-9]+").WithMessage("Sua senha deve conter no minimo um numeral.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Sua senha deve conter um caracter especial (! ? * . ).")
                .NotEmpty().WithMessage("Por favor informe a senha.");

            // Valida o campo DataCadastro
            RuleFor(u => u.DataCadastro)
                .NotEmpty().WithMessage("A data de cadastro é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de cadastro não pode ser no futuro.");

            // Valida o campo DataLogin (opcional)
            RuleFor(u => u.DataLogin)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de login não pode ser no futuro.")
                .When(u => u.DataLogin.HasValue);
        }
    }
}
