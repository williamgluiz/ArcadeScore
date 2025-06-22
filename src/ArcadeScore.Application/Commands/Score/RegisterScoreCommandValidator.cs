using FluentValidation;

namespace ArcadeScore.Application.Commands.Score
{
    public class RegisterScoreCommandValidator : AbstractValidator<RegisterScoreCommand>
    {
        public RegisterScoreCommandValidator()
        {
            RuleFor(c => c.PlayerName)
                .NotEmpty().WithMessage("Player name is required.");

            RuleFor(c => c.Score)
                .GreaterThanOrEqualTo(0).WithMessage("Score must be zero or more.");

            RuleFor(c => c.DatePlayed)
                .NotEmpty().WithMessage("Date played is required.");
        }
    }
}
