// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// EntityBase
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.SeedWork
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="EntityBase"/>
    /// </summary>
    /// <seealso cref="ComparableSeed"/>
    public abstract class EntityBase : ComparableSeed
    {
        /// <summary>
        /// The domain events
        /// </summary>
        private readonly List<IDomainEvent> domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        protected EntityBase()
        {
            this.UUId = Guid.NewGuid();

            this.domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>The domain events.</value>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => this.domainEvents;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the modification date.
        /// </summary>
        /// <value>The modification date.</value>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the uu identifier.
        /// </summary>
        /// <value>The uu identifier.</value>
        public Guid UUId { get; set; }

        /// <summary>
        /// Adds the domain event.
        /// </summary>
        /// <param name="newEvent">The new event.</param>
        public void AddDomainEvent(IDomainEvent newEvent)
        {
            this.domainEvents.Add(newEvent);
        }

        /// <summary>
        /// Clears the domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            this.domainEvents.Clear();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/>
        /// parameter; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(ComparableSeed other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if ((other as EntityBase).IsTransient())
            {
                return false;
            }

            return base.Equals(other);
        }

        /// <summary>
        /// Determines whether this instance is transient.
        /// </summary>
        /// <returns><c>true</c> if this instance is transient; otherwise, <c>false</c>.</returns>
        public bool IsTransient() => this.Id == default(Int32);
    }
}