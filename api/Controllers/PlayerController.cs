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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var playerModel = await _playerRepo.DeleteAsync(id);

            if (playerModel == null)
            {
                return NotFound("No se encontro al jugador");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlayerRequestDto updateDto)
        {
            var playerModel = await _playerRepo.UpdateAsync(id, updateDto);

            if (playerModel == null)
            {
                return NotFound("No se encontro al jugador");
            }

            return Ok(playerModel.ToPlayerDto());
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> TeamTransfer([FromRoute] int id, [FromBody] int teamId)
        {
            var playerModel = await _playerRepo.TeamTransferAsync(id, teamId);

            if (playerModel == null)
            {
                return NotFound("No se encontro al jugador");
            }

            return Ok(playerModel.ToPlayerDto());
        }
    }
}