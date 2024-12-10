using FluentValidation;
using TreinandoPráticasApi._1___Application.Models;

namespace TreinandoPráticasApi.Validators
{
    public class UsuarioUtil : AbstractValidator<UsuarioModel> 
    {
        
        public UsuarioUtil() 
        {
            RuleFor(x => x.DsNome)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(55);

            RuleFor(x => x.DsCPF)
                .NotEmpty()
                .Length(11)
                .Must(CpfUtil.ValidarFormatoCpf)
                .WithMessage("O cpf informado não é válido.");
        }
    }
}
