// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotUpdatableException.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// NotUpdatableException
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Domain.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    internal class NotUpdatableException : GameCollectorException
    {
        public NotUpdatableException(string message)
            : base(message, (int)Enum.ErrorCode.NotUpdatable)
        {
        }

        private NotUpdatableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
