// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueObject.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ValueObject
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.SeedWork
{
    using System;

    /// <summary>
    /// <see cref="ValueObject"/>
    /// </summary>
    /// <seealso cref="ComparableSeed"/>
    public abstract class ValueObject : ComparableSeed
    {
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
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            return base.Equals((ValueObject)other);
        }

        /// <summary>
        /// Gets the copy.
        /// </summary>
        /// <returns></returns>
        public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }
    }
}