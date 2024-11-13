using FluentValidation;
using TreinandoPráticasApi.DTO;

namespace TreinandoPráticasApi.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO> 
    {
        
        public UsuarioValidator() 
        {
            RuleFor(x => x.DsNome)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(55);

            RuleFor(x => x.DsCPF)
                .NotEmpty()
                .Length(11)
                .Must(CpfValidator.ValidarFormatoCpf)
                .WithMessage("o cpf informado não é válido.");
        }
    }
}
