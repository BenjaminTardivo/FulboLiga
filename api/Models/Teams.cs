using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Teams")]
    public class Teams
    {
        public int Id { get; set; }
        private string? _simbolo;
        public string? Simbolo
        {
            get => _simbolo;
            set => _simbolo = value?.ToUpper();
        }
        public string Nombre { get; set; } = string.Empty;
        public int PJ { get; set; } = 0;
        public int PG { get; set; } = 0;
        public int PE { get; set; } = 0;
        public int PP { get; set; } = 0;
        public int GF { get; set; } = 0;
        public int GC { get; set; } = 0;
        public int Diff { get; private set; }
        public int PTS { get; private set; }
        public List<Player> Jugadores { get; set; } = new List<Player>();
    }
}