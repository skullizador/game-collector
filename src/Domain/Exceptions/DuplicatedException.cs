// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DuplicatedException.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// DuplicatedException
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
    public sealed class DuplicatedException : GameCollectorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DuplicatedException(string message)
            : base(message, (int)Enum.ErrorCode.Duplicated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        private DuplicatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}