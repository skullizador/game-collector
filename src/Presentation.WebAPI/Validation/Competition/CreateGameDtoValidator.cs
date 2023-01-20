// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateGameDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateGameDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    public class CreateGameDtoValidator : AbstractValidator<CreateGameDto>
    {
        public CreateGameDtoValidator() 
        {
            this.RuleFor(x => x.TeamAId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamAId shouldn't have the default value.");

            this.RuleFor(x => x.TeamBId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamBId shouldn't have the default value.");

            this.RuleFor(x => x.Score)
                .NotEmpty()
                    .WithMessage("The Score shouldn't be empty.")
                .MaximumLength(2)
                    .WithMessage("The Score shouldn't be longer than 2 characters.");

            this.RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                    .WithMessage("The Start Date shoudn't be older than the current date.");



        }
    }
}
