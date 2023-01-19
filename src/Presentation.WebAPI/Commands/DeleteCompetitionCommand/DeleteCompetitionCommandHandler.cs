// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteCompetitionCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteCompetitionCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.DeleteCompetitionCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using GameCollector.Infrastructure;
    using GameCollector.Infrastructure.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// <see cref="DeleteCompetitionCommandHandler"/>
    /// </summary>
    /// <seealso cref="INotificationHandler{DeleteCompetitionCommand};" />
    public class DeleteCompetitionCommandHandler : INotificationHandler<DeleteCompetitionCommand>
    {
        /// <summary>
        /// The competition repository
        /// </summary>
        private readonly ICompetitionRepository competitionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCompetitionCommandHandler"/> class.
        /// </summary>
        /// <param name="competitionRepository">The competition repository.</param>
        public DeleteCompetitionCommandHandler(ICompetitionRepository competitionRepository)
        {
            this.competitionRepository = competitionRepository;
        }
        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="NotFoundException">The Competition with id {notification.CompetitionId} wasn't found.</exception>
        public async Task Handle(DeleteCompetitionCommand notification, CancellationToken cancellationToken)
        {
            Competition competition = await this.competitionRepository.GetAsync(notification.CompetitionId, cancellationToken);

            if(competition is null)
            {
                throw new NotFoundException($"The Competition with id {notification.CompetitionId} wasn't found.");
            }

            await this.competitionRepository.Remove(competition, cancellationToken);

            await this.competitionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
