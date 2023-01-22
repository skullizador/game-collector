// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    public class UpdateGameLiveDto
    {
        public UpdateGameLiveDto()
        {
            this.Score = string.Empty;
        }
        public string Score { get; init; }
    }
}
