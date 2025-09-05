using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DNI { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public int PJ { get; set; }
        public int Goles { get; set; }
        public int GolEnContra { get; set; }
        public int Amarillas { get; set; }
        public int Rojas { get; set; }

        public int? TeamId { get; set; }
        public Teams? Team { get; set; }
    }
}