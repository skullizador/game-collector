﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    public class UpdateGameCommand : IRequest<Game>
    {
        public DateTime StartDate { get; init; }
        public Guid TeamAId { get; init; }
        public Guid TeamBId { get; init; }
        public Guid GameId { get; init; }
    }
}