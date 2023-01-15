﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitionController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CompetitionController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Output.Competition;
    using GameCollector.Presentation.WebAPI.Queries.Competition.GetByCompetitionIdQuery;
    using GameCollector.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="CompetitionController"/>
    /// </summary>
    /// <seealso cref="Controller"/>
    [ApiController]
    [Route("api/v1/Competition")]
    public class CompetitionController : Controller
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
        /// Initializes a new instance of the <see cref="CompetitionController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="mediator">The mediator.</param>
        public CompetitionController(
            IMapper mapper,
            IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the by competition identifier asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{CompetitionId}")]
        [ProducesResponseType(typeof(CompetitionDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCompetitionIdAsync([FromRoute] GetByCompetitionIdDto filter, CancellationToken cancellationToken)
        {
            Competition competition = await this.mediator.Send(new GetByCompetitionIdQuery
            {
                CompetitionId = filter.CompetitionId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<CompetitionDetailsDto>(competition));
        }
    }
}