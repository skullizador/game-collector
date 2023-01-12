// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComparableSeed.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ComparableSeed
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.SeedWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <see cref="ComparableSeed"/>
    /// </summary>
    /// <seealso cref="IEquatable{ComparableSeed}"/>
    public abstract class ComparableSeed : IEquatable<ComparableSeed>
    {
        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="leftHand">The left hand.</param>
        /// <param name="rightHand">The right hand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ComparableSeed leftHand, ComparableSeed rightHand) => !(leftHand == rightHand);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="leftHand">The left hand.</param>
        /// <param name="rightHand">The right hand.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ComparableSeed leftHand, ComparableSeed rightHand)
        {
            if (leftHand is null)
            {
                if (rightHand is null)
                {
                    return true;
                }

                return false;
            }

            return leftHand.Equals(rightHand);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => Equals(obj as ComparableSeed);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/>
        /// parameter; otherwise, <see langword="false"/>.
        /// </returns>
        public virtual bool Equals(ComparableSeed other)
        {
            IEnumerator<object> thisValues = this.GetAtomicValues().GetEnumerator();

            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                {
                    return false;
                }

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data
        /// structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Gets the atomic values.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetAtomicValues();
    }
}