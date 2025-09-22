using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Player;
using api.Models;

namespace api.Controllers.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string? Simbolo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int PJ { get; set; }
        public int PG { get; set; }
        public int PE { get; set; }
        public int PP { get; set; }
        public int Diff { get; set; }
        public int PTS { get; set; }
        public List<PlayerDto> Jugadores { get; set; }
    }
}