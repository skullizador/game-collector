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

    /// <summary>
    /// <see cref="UpdateOddCommand"/>
    /// </summary>
    /// <seealso cref="IRequest{Odd}"/>
    public class UpdateOddCommand : IRequest<Odd>
    {
        /// <summary>
        /// Gets the odd identifier.
        /// </summary>
        /// <value>The odd identifier.</value>
        public Guid OddId { get; init; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; init; }
    }
}