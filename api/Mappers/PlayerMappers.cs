using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Player;
using api.Models;

namespace api.Mappers
{
    public static class PlayerMappers
    {
        public static PlayerDto ToPlayerDto(this Player playerModel)
        {
            return new PlayerDto
            {
                Id = playerModel.Id,
                DNI = playerModel.DNI,
                Nombre = playerModel.Nombre,
                Edad = playerModel.Edad,
                PJ = playerModel.PJ,
                Goles = playerModel.Goles,
                GolEnContra = playerModel.GolEnContra,
                Amarillas = playerModel.Amarillas,
                Rojas = playerModel.Rojas
            };
        }

        public static Player ToPlayerFromCreateDto(this CreatePlayerRequestDto playerDto, int teamId)
        {
            return new Player
            {
                DNI = playerDto.DNI,
                Nombre = playerDto.Nombre,
                Edad = playerDto.Edad,
                PJ = playerDto.PJ,
                Goles = playerDto.Goles,
                GolEnContra = playerDto.GolEnContra,
                Amarillas = playerDto.Amarillas,
                Rojas = playerDto.Rojas,
                TeamId = teamId
            };
            
        }
    }
}