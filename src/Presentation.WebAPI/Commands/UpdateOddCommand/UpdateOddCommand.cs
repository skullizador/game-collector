// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOddCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// UpdateOddCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Commands.UpdateOddCommand
{
    using GameCollector.Domain.AggregateModels.Competition;
    using MediatR;

    public class UpdateOddCommand : IRequest<Odd>
    {
        public Guid OddId { get; init; }
        public decimal Value { get; init; }
    }
}
