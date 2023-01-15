// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetByCompetitionIdDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GetByCompetitionIdDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="GetByCompetitionIdDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{GetByCompetitionIdDto}"/>
    public class GetByCompetitionIdDtoValidator : AbstractValidator<GetByCompetitionIdDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByCompetitionIdDtoValidator"/> class.
        /// </summary>
        public GetByCompetitionIdDtoValidator()
        {
            RuleFor(x => x.CompetitionId)
                .NotEqual(Guid.Empty)
                    .WithMessage("The CompetitionId shouldn't have the default value.");
        }
    }
}