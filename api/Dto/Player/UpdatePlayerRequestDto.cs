using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Player
{
    public class UpdatePlayerRequestDto
    {
        [Required]
        public int DNI { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del equipo no puede tener mas de 20 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Range(5, 50)]
        public int Edad { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int PJ { get; set; } = 0;
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int Goles { get; set; } = 0;
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int GolEnContra { get; set; } = 0;
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int Amarillas { get; set; } = 0;
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int Rojas { get; set; } = 0;
    }
}