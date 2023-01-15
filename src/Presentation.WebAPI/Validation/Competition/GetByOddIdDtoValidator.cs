// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByOddIdDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByOddIdDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="GetByOddIdDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{GetByOddIdDto}"/>
    public class GetByOddIdDtoValidator : AbstractValidator<GetByOddIdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByOddIdDtoValidator"/> class.
        /// </summary>
        public GetByOddIdDtoValidator()
        {
            RuleFor(x => x.OddId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The OddId shouldn't have the default value.");
        }
    }
}