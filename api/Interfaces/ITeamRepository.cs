using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.team;
using api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace api.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Teams>> GetAllAsync();
        Task<Teams?> GetByIdAsync(int id);
        Task<Teams> CreateAsync(Teams teamModel);
        Task<Teams?> UpdateAsync(int id, UpdateTeamRequestDto teamDto);
        Task<Teams?> DeleteAsync(int id);
        Task<Teams?> PatchAsync(int id, JsonPatchDocument<Teams> patchDoc);
    }
}