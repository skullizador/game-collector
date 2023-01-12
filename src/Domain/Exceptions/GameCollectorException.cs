// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameCollectorException.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameCollectorException
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// <see cref="GameCollectorException"/>
    /// </summary>
    /// <seealso cref="Exception"/>
    [Serializable]
    public class GameCollectorException : Exception
    {
        /// <summary>
        /// The error code
        /// </summary>
        [NonSerialized]
        private readonly int errorCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public GameCollectorException(int errorCode)
            : base()
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public GameCollectorException(string message, int errorCode)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference ( <see
        /// langword="Nothing"/> in Visual Basic) if no inner exception is specified.
        /// </param>
        public GameCollectorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        /// <param name="errorCode">The error code.</param>
        public GameCollectorException(SerializationInfo info, StreamingContext context, int errorCode)
            : this(info, context)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCollectorException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected GameCollectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode => this.errorCode;

        /// <summary>
        /// When overridden in a derived class, sets the <see
        /// cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        [ExcludeFromCodeCoverage]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(this.ErrorCode), this.ErrorCode, typeof(int));
        }
    }
}