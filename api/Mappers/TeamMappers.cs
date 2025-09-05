using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dto;
using api.Dto.team;
using api.Models;

namespace api.Mappers
{
    public static class TeamMappers
    {
        public static TeamDto toTeamDto(this Teams teamModel)
        {
            return new TeamDto
            {
                Id = teamModel.Id,
                Simbolo = teamModel.Simbolo.ToUpper(),
                Nombre = teamModel.Nombre,
                PJ = teamModel.PJ,
                PG = teamModel.PG,
                PE = teamModel.PE,
                PP = teamModel.PP,
                Diff = teamModel.Diff,
                PTS = teamModel.PTS
            };
        }

        public static Teams ToTeamsFromCreate(this CreateTeamRequestDto teamDto)
        {
            return new Teams
            {
                Simbolo = teamDto.Simbolo.ToUpper(),
                Nombre = teamDto.Nombre,
                PJ = teamDto.PJ,
                PG = teamDto.PG,
                PE = teamDto.PE,
                PP = teamDto.PP,
            };
        }
    }
}