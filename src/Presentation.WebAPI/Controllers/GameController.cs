// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameController.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// GameController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Controllers
{
    using System.Net;
    using AutoMapper;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Presentation.WebAPI.Commands.CreateGameCommand;
    using GameCollector.Presentation.WebAPI.Commands.DeleteGameCommand;
    using GameCollector.Presentation.WebAPI.Commands.UpdateGameCommand;
    using GameCollector.Presentation.WebAPI.Commands.UpdateGameLiveCommand;
    using GameCollector.Presentation.WebAPI.Dtos.Input.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Output.Competition;
    using GameCollector.Presentation.WebAPI.Queries.Competition.GetByGameIdQuery;
    using GameCollector.Presentation.WebAPI.Queries.Competition.GetGamesByCompetitionIdQuery;
    using GameCollector.Presentation.WebAPI.Utils;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// <see cref="GameController"/>
    /// </summary>
    /// <seealso cref="Controller"/>
    [ApiController]
    [Route("api/v1/Game")]
    public class GameController : Controller
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
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="mediator">The mediator.</param>
        public GameController(
            IMapper mapper,
            IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        /// <summary>
        /// Adds the game to competition asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="createGameDto">The create game dto.</param>
        /// <param name="cancelationToken">The cancelation token.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GameDetailsDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddGameToCompetitionAsync(
            [FromQuery] GetByCompetitionIdDto filters,
            [FromBody] CreateGameDto createGameDto,
            CancellationToken cancelationToken)
        {
            Game game = await this.mediator.Send(new CreateGameCommand
            {
                CompetitionId = filters.CompetitionId,
                TeamAId = createGameDto.TeamAId,
                TeamBId = createGameDto.TeamBId,
                StartDate = createGameDto.StartDate,
            }, cancelationToken);

            return this.Created(string.Empty, this.mapper.Map<GameDetailsDto>(game));
        }

        /// <summary>
        /// Deletes the game asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpDelete("{GameId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteGameAsync([FromRoute] GetByGameIdDto filter, CancellationToken cancellationToken)
        {
            await this.mediator.Publish(new DeleteGameCommand
            {
                GameId = filter.GameId
            }, cancellationToken);

            return this.Ok();
        }

        /// <summary>
        /// Gets the by competition identifier asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GameDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCompetitionIdAsync([FromQuery] GetByCompetitionIdDto filter, CancellationToken cancellationToken)
        {
            IEnumerable<Game> games = await this.mediator.Send(new GetGamesByCompetitionIdQuery
            {
                CompetitionId = filter.CompetitionId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<IEnumerable<GameDto>>(games));
        }

        /// <summary>
        /// Gets the by game identifier asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{GameId}")]
        [ProducesResponseType(typeof(GameDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByGameIdAsync([FromRoute] GetByGameIdDto filters, CancellationToken cancellationToken)
        {
            Game game = await this.mediator.Send(new GetByGameIdQuery
            {
                GameId = filters.GameId
            }, cancellationToken);

            return this.Ok(this.mapper.Map<GameDetailsDto>(game));
        }

        /// <summary>
        /// Updates the game asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="updateGameDto">The update game dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut("{GameId}")]
        [ProducesResponseType(typeof(GameDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateGameAsync(
            [FromRoute] GetByGameIdDto filters,
            [FromBody] UpdateGameDto updateGameDto,
            CancellationToken cancellationToken)
        {
            Game game = await this.mediator.Send(new UpdateGameCommand
            {
                GameId = filters.GameId,
                StartDate = updateGameDto.StartDate,
                TeamAId = updateGameDto.TeamAId,
                TeamBId = updateGameDto.TeamBId,
            }, cancellationToken);

            return this.Ok(this.mapper.Map<GameDetailsDto>(game));
        }

        /// <summary>
        /// Updates the game live asynchronous.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="updateGameLiveDto">The update game live dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPut("{GameId}/Live")]
        [ProducesResponseType(typeof(GameDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateGameLiveAsync(
            [FromRoute] GetByGameIdDto filters,
            [FromBody] UpdateGameLiveDto updateGameLiveDto,
            CancellationToken cancellationToken)
        {
            Game game = await this.mediator.Send(new UpdateGameLiveCommand
            {
                GameId = filters.GameId,
                Score = updateGameLiveDto.Score,
            }, cancellationToken);

            return this.Ok(this.mapper.Map<GameDetailsDto>(game));
        }
    }
}