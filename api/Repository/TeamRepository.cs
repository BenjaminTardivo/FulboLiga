using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.team;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _context;
        public TeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Teams> CreateAsync(Teams teamModel)
        {
            await _context.Teams.AddAsync(teamModel);
            await _context.SaveChangesAsync();
            return teamModel;
        }

        public async Task<Teams?> DeleteAsync(int id)
        {
            var teamModel = await _context.Teams.FindAsync(id);

            if (teamModel == null)
            {
                return null;
            }
            _context.Teams.Remove(teamModel);
            _context.SaveChanges();
            return teamModel;
        }

        public async Task<List<Teams>> GetAllAsync()
        {
            return await _context.Teams.Include(p => p.Jugadores).ToListAsync();
        }

        public async Task<Teams?> GetByIdAsync(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teams?> PatchAsync(int id, JsonPatchDocument<Teams> patchDoc)
        {
            var existingTeam = await _context.Teams.FindAsync(id);

            if (existingTeam == null)
            {
                return null;
            }

            patchDoc.ApplyTo(existingTeam);

            await _context.SaveChangesAsync();

            return existingTeam;
        }

        public async Task<Teams?> UpdateAsync(int id, UpdateTeamRequestDto teamDto)
        {
            var existingTeam = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (existingTeam == null)
            {
                return null;
            }

            existingTeam.Simbolo = teamDto.Simbolo.ToUpper();
            existingTeam.Nombre = teamDto.Nombre;
            existingTeam.PJ = teamDto.PJ;
            existingTeam.PG = teamDto.PG;
            existingTeam.PP = teamDto.PP;
            existingTeam.PE = teamDto.PE;
            existingTeam.GF = teamDto.GF;
            existingTeam.GC = teamDto.GC;

            await _context.SaveChangesAsync();

            return existingTeam;
        }
    }
}