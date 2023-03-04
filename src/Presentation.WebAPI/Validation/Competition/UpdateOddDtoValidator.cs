// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOddDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateOddDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="UpdateOddDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateOddDto}"/>
    public class UpdateOddDtoValidator : AbstractValidator<UpdateOddDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOddDtoValidator"/> class.
        /// </summary>
        public UpdateOddDtoValidator()
        {
            this.RuleFor(x => x.Value)
                .GreaterThan(1)
                    .WithMessage("The odd Value shouldn't be lower than 1.");
        }
    }
}