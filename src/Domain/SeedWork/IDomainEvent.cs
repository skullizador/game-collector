// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainEvent.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// IDomainEvent
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.SeedWork
{
    using MediatR;

    /// <summary>
    /// <see cref="IDomainEvent"/>
    /// </summary>
    /// <seealso cref="INotification"/>
    public interface IDomainEvent : INotification
    {
    }
}