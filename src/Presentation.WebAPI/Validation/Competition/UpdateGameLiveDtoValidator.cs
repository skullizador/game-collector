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

    public class UpdateGameLiveDtoValidator : AbstractValidator<UpdateGameLiveDto>
    {
        public UpdateGameLiveDtoValidator()
        {
            this.RuleFor(x => x.Score)
                .NotEmpty()
                    .WithMessage("The Score shouldn't be empty.");
        }
    }
}
