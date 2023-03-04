// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveDtoValidator.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveDtoValidator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Validation.Competition
{
    using FluentValidation;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;

    /// <summary>
    /// <see cref="UpdateGameLiveDtoValidator"/>
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateGameLiveDto}"/>
    public class UpdateGameLiveDtoValidator : AbstractValidator<UpdateGameLiveDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGameLiveDtoValidator"/> class.
        /// </summary>
        public UpdateGameLiveDtoValidator()
        {
            this.RuleFor(x => x.Score)
                .NotEmpty()
                    .WithMessage("The Score shouldn't be empty.");
        }
    }
}