using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Player;
using api.Dto.team;
using api.Models;

namespace api.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player> CreateAsync(Player playerModel);
        Task<Player?> DeleteAsync(int id);
        Task<Player?> UpdateAsync(int id, UpdatePlayerRequestDto updateDto);
        Task<Player?> TeamTransferAsync(int id, int teamId);
    }
}