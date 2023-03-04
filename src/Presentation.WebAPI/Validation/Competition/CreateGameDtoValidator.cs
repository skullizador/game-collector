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

    /// <summary>
    /// <see cref="CreateGameDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateGameDto}"/>
    public class CreateGameDtoValidator : AbstractValidator<CreateGameDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGameDtoValidator"/> class.
        /// </summary>
        public CreateGameDtoValidator()
        {
            this.RuleFor(x => x.TeamAId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamAId shouldn't have the default value.");

            this.RuleFor(x => x.TeamBId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamBId shouldn't have the default value.");

            this.RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                    .WithMessage("The Start Date shoudn't be older than the current date.");
        }
    }
}