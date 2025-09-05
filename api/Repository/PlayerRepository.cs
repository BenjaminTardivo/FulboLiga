using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
    }
}