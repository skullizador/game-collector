// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionMiddleware.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// ExceptionMiddleware
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Exceptions.Middleware
{
    using System.Net;
    using GameCollector.Domain.Exceptions;
    using GameCollector.Presentation.WebAPI.Utils;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="ExceptionMiddleware"/>
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// The exception codes
        /// </summary>
        private readonly Dictionary<Type, HttpStatusCode> exceptionCodes;

        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;

            this.exceptionCodes = new();

            this.MapExceptionsAndCodes();
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"{this.GetType().Name}.InvokeAsync");

                await this.HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private HttpStatusCode GetStatusCode(Exception exception)
        {
            var type = exception.GetType();

            if (this.exceptionCodes.ContainsKey(type))
            {
                return this.exceptionCodes.GetValueOrDefault(type);
            }

            return HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)this.GetStatusCode(exception);

            var task = context.Response.WriteAsync(
                JsonConvert.SerializeObject(
                    new ErrorMessage
                    {
                        Status = context.Response.StatusCode,
                        Message = exception.Message
                    },
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));

            return task;
        }

        /// <summary>
        /// Maps the exceptions and codes.
        /// </summary>
        private void MapExceptionsAndCodes()
        {
            this.exceptionCodes.Add(typeof(NotFoundException), HttpStatusCode.NotFound);
            this.exceptionCodes.Add(typeof(DuplicatedException), HttpStatusCode.BadRequest);
        }
    }
}