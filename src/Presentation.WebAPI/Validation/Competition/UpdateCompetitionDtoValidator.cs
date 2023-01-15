// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCompetitionDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateCompetitionDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="UpdateCompetitionDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateCompetitionDto}"/>
    public class UpdateCompetitionDtoValidator : AbstractValidator<UpdateCompetitionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompetitionDtoValidator"/> class.
        /// </summary>
        public UpdateCompetitionDtoValidator()
        {
            this.RuleFor(x => x.Region)
                .NotEmpty()
                    .WithMessage("The Region shouldn't be empty.")
                .MaximumLength(50)
                    .WithMessage("The Region shouldn't be longer than 50 characters.");

            this.RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("The Description shouldn't be empty.")
                .MaximumLength(255)
                    .WithMessage("The Description shouldn't be longer than 50 characters.");

            this.RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("The Year lower than the current year.");
        }
    }
}