// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteOddCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteOddCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Commands.DeleteOddCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// <see cref="DeleteOddCommandHandler"/>
    /// </summary>
    /// <seealso cref="INotificationHandler{DeleteOddCommand}" />
    public class DeleteOddCommandHandler : INotificationHandler<DeleteOddCommand>
    {
        /// <summary>
        /// The odd repository
        /// </summary>
        private readonly IOddRepository oddRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOddCommandHandler"/> class.
        /// </summary>
        /// <param name="oddRepository">The odd repository.</param>
        public DeleteOddCommandHandler(IOddRepository oddRepository)
        {
            this.oddRepository = oddRepository;
        }
        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="NotFoundException">The Odd with id {notification.OddId} wasn't found.</exception>
        public async Task Handle(DeleteOddCommand notification, CancellationToken cancellationToken)
        {
            Odd odd = await this.oddRepository.GetAsync(notification.OddId, cancellationToken);

            if(odd is null)
            {
                throw new NotFoundException($"The Odd with id {notification.OddId} wasn't found.");
            }

            await this.oddRepository.Remove(odd, cancellationToken);

            await this.oddRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
