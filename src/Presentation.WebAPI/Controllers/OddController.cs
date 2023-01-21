// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OddController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// OddController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Presentation.WebAPI.Commands.UpdateOddCommand;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Output.Competition;
    using GameCollector.Presentation.WebAPI.Queries.Competition.GetByOddIdQuery;
    using GameCollector.Presentation.WebAPI.Queries.Competition.GetOddsByGameIdQuery;
    using GameCollector.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="OddController"/>
    /// </summary>
    /// <seealso cref="Controller"/>
    [ApiController]
    [Route("api/v1/Odd")]
    public class OddController : Controller
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OddController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        public OddController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the by game identifier asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OddDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByGameIdAsync([FromQuery] GetByGameIdDto filter, CancellationToken cancellationToken)
        {
            IEnumerable<Odd> odd = await this.mediator.Send(new GetOddsByGameIdQuery
            {
                GameId = filter.GameId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<IEnumerable<OddDto>>(odd));
        }

        /// <summary>
        /// Gets the by odd identifier asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{OddId}")]
        [ProducesResponseType(typeof(OddDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByOddIdAsync([FromRoute] GetByOddIdDto filter, CancellationToken cancellationToken)
        {
            Odd odd = await this.mediator.Send(new GetByOddIdQuery
            {
                OddId = filter.OddId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<OddDetailsDto>(odd));
        }

        [HttpPut("{OddId}")]
        [ProducesResponseType(typeof(OddDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage),(int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateOddAsync(
            [FromRoute] GetByOddIdDto filters, 
            [FromBody] UpdateOddDto updateOddDto, 
            CancellationToken cancellationToken)
        {
            Odd odd = await this.mediator.Send(new UpdateOddCommand
            {
                OddId = filters.OddId,
                Value = updateOddDto.Value,
            }, cancellationToken) ;

            return this.Ok(this.mapper.Map<OddDetailsDto>(odd));
        }
    }
}