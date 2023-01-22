// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateGameLiveCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateGameLiveCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameLiveCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    public class UpdateGameLiveCommand : IRequest<Game>
    {
        public UpdateGameLiveCommand() 
        {
            this.Score = string.Empty;
        }
        public Guid GameId { get; init; }
        public string Score { get; init; }
    }
}
