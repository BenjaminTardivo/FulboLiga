using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Player;
using api.Dto.team;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDBContext _context;
        public PlayerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Player> CreateAsync(Player playerModel)
        {
            await _context.Player.AddAsync(playerModel);
            await _context.SaveChangesAsync();
            return playerModel;
        }

        public async Task<Player?> DeleteAsync(int id)
        {
            var playerModel = await _context.Player.FindAsync(id);

            if (playerModel == null)
            {
                return null;
            }

            _context.Player.Remove(playerModel);
            await _context.SaveChangesAsync();

            return playerModel;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Player.ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            var playerModel = await _context.Player.FindAsync(id);

            if (playerModel == null)
            {
                return null;
            }

            return playerModel;
        }

        public async Task<Player?> TeamTransferAsync(int id, int teamId)
        {
            var playerModel = await _context.Player.FindAsync(id);

            if (playerModel == null)
            {
                return null;
            }

            playerModel.TeamId = teamId;

            return playerModel;
        }

        public async Task<Player?> UpdateAsync(int id, UpdatePlayerRequestDto updateDto)
        {
            var playerModel = await _context.Player.FindAsync(id);

            if (playerModel == null)
            {
                return null;
            }

            playerModel.DNI = updateDto.DNI;
            playerModel.Nombre = updateDto.Nombre;
            playerModel.Edad = updateDto.Edad;
            playerModel.PJ = updateDto.PJ;
            playerModel.Goles = updateDto.Goles;
            playerModel.GolEnContra = updateDto.GolEnContra;
            playerModel.Amarillas = updateDto.Amarillas;
            playerModel.Rojas = updateDto.Rojas;

            await _context.SaveChangesAsync();

            return playerModel;
        }
    }
}