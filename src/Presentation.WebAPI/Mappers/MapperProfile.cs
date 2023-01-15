// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapperProfile.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// MapperProfile
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Mappers
{
    using AutoMapper;
    using GameCollector.Domain.AggregateModels.Competition;
    using GameCollector.Presentation.WebAPI.Dtos.Output.Competition;

    /// <summary>
    /// <see cref="MapperProfile"/>
    /// </summary>
    /// <seealso cref="Profile"/>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperProfile"/> class.
        /// </summary>
        public MapperProfile()
        {
            this.CreateMap<Competition, CompetitionDetailsDto>();

            this.CreateMap<Competition, CompetitionDto>();

            this.CreateMap<Game, GameDetailsDto>();

            this.CreateMap<Game, GameDto>();

            this.CreateMap<Odd, OddDetailsDto>();

            this.CreateMap<Odd, OddDto>();
        }
    }
}