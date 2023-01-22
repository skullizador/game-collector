// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCompetitionDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateCompetitionDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="CreateCompetitionDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateCompetitionDto}"/>
    public class CreateCompetitionDtoValidator : AbstractValidator<CreateCompetitionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompetitionDtoValidator"/> class.
        /// </summary>
        public CreateCompetitionDtoValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("The Name shouldn't be empty.")
                .MaximumLength(50)
                    .WithMessage("The Name shouldn't be longer than 50 characters.");

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

            this.RuleFor(x => x.Type)
                .IsInEnum()
                    .WithMessage("The Type should be a valid enum value.");

            this.RuleFor(x => x.Sport)
                .IsInEnum()
                    .WithMessage("The Type should be a valid enum value.");

            this.RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("The Year shoudn't be lower than the current year.");
        }
    }
}