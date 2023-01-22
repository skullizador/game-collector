// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    public class UpdateGameDto
    {
        public DateTime StartDate { get; init; }
        public Guid TeamAId { get; init; }
        public Guid TeamBId { get; init; }
    }
}
