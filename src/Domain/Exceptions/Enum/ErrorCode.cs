// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorCode.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ErrorCode
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GameCollector.Domain.Exceptions.Enum
{
    /// <summary>
    /// <see cref="ErrorCode"/>
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// The not found
        /// </summary>
        NotFound = 201,

        /// <summary>
        /// The duplicated
        /// </summary>
        Duplicated = 202,

        /// <summary>
        /// The invalid odd
        /// </summary>
        InvalidOdd = 203,
    }
}