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
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;
    using System.Runtime.CompilerServices;

    public class UpdateOddDtoValidator : AbstractValidator<UpdateOddDto>
    {
        public UpdateOddDtoValidator()
        {
            this.RuleFor(x => x.Value)
                .GreaterThan(1)
                    .WithMessage("The odd Value shouldn't be lower than 1.");
        }
    }
}
