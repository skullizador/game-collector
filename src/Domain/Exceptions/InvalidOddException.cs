// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOddException.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// InvalidOddException
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// <see cref="NotFoundException"/>
    /// </summary>
    /// <seealso cref="GameCollectorException"/>
    [Serializable]
    public sealed class InvalidOddException : GameCollectorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOddException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidOddException(string message)
            : base(message, (int)Enum.ErrorCode.InvalidOdd)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOddException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        private InvalidOddException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}