// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateOddDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateOddDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="CreateOddDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateOddDto}"/>
    public class CreateOddDtoValidator : AbstractValidator<CreateOddDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOddDtoValidator"/> class.
        /// </summary>
        public CreateOddDtoValidator()
        {
            this.RuleFor(x => x.BookmakerId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The Bookmaker Id shouldn't be empty.");

            this.RuleFor(x => x.Type)
                .NotEmpty()
                    .WithMessage("The odd Type shouldn't be empty.");

            this.RuleFor(x => x.Value)
                .GreaterThan(1)
                    .WithMessage("The odd Value shouldn't be lower than 1.");
        }
    }
}