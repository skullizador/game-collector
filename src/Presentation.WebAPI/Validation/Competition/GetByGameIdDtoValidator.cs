// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByGameIdDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByGameIdDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="GetByGameIdDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{GetByGameIdDto}"/>
    public class GetByGameIdDtoValidator : AbstractValidator<GetByGameIdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByGameIdDtoValidator"/> class.
        /// </summary>
        public GetByGameIdDtoValidator()
        {
            this.RuleFor(x => x.GameId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The GameId shouldn't have the default value.");
        }
    }
}