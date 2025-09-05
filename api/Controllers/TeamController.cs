using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.team;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepo;
        public TeamController(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teams = await _teamRepo.GetAllAsync();
            var teamsDto = teams.Select(t => t.toTeamDto()).ToList();

            return Ok(teamsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _teamRepo.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team.toTeamDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamRequestDto teamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamModel = teamDto.ToTeamsFromCreate();
            await _teamRepo.CreateAsync(teamModel);
            return CreatedAtAction(nameof(GetById), new { id = teamModel.Id }, teamModel.toTeamDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTeamRequestDto updateDto)
        {
            var teamModel = await _teamRepo.UpdateAsync(id, updateDto);

            if (teamModel == null)
            {
                return NotFound("El equipo no existe");
            }

            return Ok(teamModel.toTeamDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var teamModel = await _teamRepo.DeleteAsync(id);

            if (teamModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> Patch([FromRoute] int id,
        [FromBody] JsonPatchDocument<Teams> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var teamModel = await _teamRepo.PatchAsync(id, patchDoc);

            if (teamModel == null)
            {
                return NotFound("El equipo no existe");
            }

            return Ok(teamModel);
        }
    }
}