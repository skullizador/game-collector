// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOddCommandHandler.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateOddCommandHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Commands.UpdateOddCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Domain.AggregateModels.Competition.Repository;
    using GameCollector.Domain.Exceptions;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOddCommandHandler : IRequestHandler<UpdateOddCommand, Odd>
    {

        private readonly IOddRepository oddRepository;

        public UpdateOddCommandHandler(IOddRepository oddRepository)
        {
            this.oddRepository = oddRepository; 
        }
        public async Task<Odd> Handle(UpdateOddCommand request, CancellationToken cancellationToken)
        {
            Odd odd = await this.oddRepository.GetAsync(request.OddId, cancellationToken);

            if (odd is null)
            {
                throw new NotFoundException($"The odd with id {request.OddId} wasn't found.");
            }

            odd.Update(request.Value);

            await this.oddRepository.Update(odd, cancellationToken);

            await this.oddRepository.UnitOfWork.SaveEntitiesAsync();

            return odd;
        }
    }
}
