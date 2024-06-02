using FluentValidation;

namespace CineamService.Command.Seance.RegisterSeance
{
    internal class RegisterSeanceCommandValidator : AbstractValidator<RegisterSeanceCommand>
    {
        public RegisterSeanceCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.NumberOfTickets).NotEmpty().GreaterThan(1);
            RuleFor(x => x.SeanceDate).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}
