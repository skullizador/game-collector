// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteOddCommand.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DeleteOddCommand
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace GameCollector.Presentation.WebAPI.Commands.DeleteOddCommand
{
    using MediatR;

    /// <summary>
    /// <see cref="DeleteOddCommand"/>
    /// </summary>
    /// <seealso cref="INotification" />
    public class DeleteOddCommand : INotification
    {
        /// <summary>
        /// Gets the odd identifier.
        /// </summary>
        /// <value>
        /// The odd identifier.
        /// </value>
        public Guid OddId { get; init; }
    }
}
