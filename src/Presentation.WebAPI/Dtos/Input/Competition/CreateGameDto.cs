// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateGameDto.cs" company="HumbleBets">
//     Copyright (c) HumbleBets. All rights reserved.
// </copyright>
// <summary>
// CreateGameDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameCollector.Presentation.WebAPI.Dtos.Input.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateGameDto
    {

        public CreateGameDto()
        {
            this.Score = string.Empty;
        }

        public string Score { get; init; }

        public DateTime StartDate { get; init; }

        public Guid TeamAId { get; init; }

        public Guid TeamBId { get; init; }

    }
}
