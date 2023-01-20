// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateGameCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateGameCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Commands.CreateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    public class CreateGameCommand : IRequest<Game>
    {
        public CreateGameCommand()
        {
            this.Score = string.Empty;
        }
        public string Score { get; init; }

        public DateTime StartDate { get; init; }

        public Guid TeamAId { get; init; }

        public Guid TeamBId { get; init; }

        public Guid CompetitionId { get; init; }
    }
}
