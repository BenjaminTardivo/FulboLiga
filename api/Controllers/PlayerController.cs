using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Player;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepo;
        public PlayerController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playerModels = await _playerRepo.GetAllAsync();

            return Ok(playerModels.Select(t => t.ToPlayerDto()).ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var playerModel = await _playerRepo.GetByIdAsync(id);

            if (playerModel == null)
            {
                return NotFound("No se encontro al jugador");
            }

            return Ok(playerModel.ToPlayerDto());
        }

        [HttpPost("{teamId}")]
        public async Task<IActionResult> Create([FromRoute] int teamId, [FromBody] CreatePlayerRequestDto playerDto)
        {
            var playerModel = playerDto.ToPlayerFromCreateDto(teamId);
            await _playerRepo.CreateAsync(playerModel);
            return CreatedAtAction(nameof(GetById), new { id = playerModel.Id }, playerModel.ToPlayerDto());
        }
    }
}