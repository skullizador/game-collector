namespace GameCollector.Presentation.WebAPI.Commands.UpdateGameCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    public class UpdateGameCommand : IRequest<Game>
    {
        public UpdateGameCommand()
        {
            this.Score = string.Empty;
        }

        public string Score { get; init; }

        public DateTime StartDate { get; init; }
        public Guid TeamAId { get; init; }
        public Guid TeamBId { get; init; }

        public Guid GameId { get; init; }

    }
}
