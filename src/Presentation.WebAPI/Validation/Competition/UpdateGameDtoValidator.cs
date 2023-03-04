// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="UpdateGameDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateGameDto}"/>
    public class UpdateGameDtoValidator : AbstractValidator<UpdateGameDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameDtoValidator"/> class.
        /// </summary>
        public UpdateGameDtoValidator()
        {
            this.RuleFor(x => x.TeamAId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamAId shouldn't be empty.");

            this.RuleFor(x => x.TeamBId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The TeamAId shouldn't be empty.");

            this.RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                    .WithMessage("The Start Date shoudn't be older than the current date.");
        }
    }
}