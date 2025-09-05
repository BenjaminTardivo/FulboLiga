using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.team
{
    public class UpdateTeamRequestDto
    {
        [MaxLength(6, ErrorMessage = "El simbolo no puede tener mas de 6 caracteres")]
        public string? Simbolo { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre del equipo no puede tener mas de 20 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int PJ { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int PG { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int PE { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int PP { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int GF { get; set; }
        [Required]
        [Range(0, 500)]
        [DefaultValue(0)]
        public int GC { get; set; }       
    }
}