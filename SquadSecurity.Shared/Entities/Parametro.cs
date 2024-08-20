using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class Parametro
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Nombre { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Valor { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Abreviatura { get; set; }

        // AUDITORIA
        [MaxLength(10)]
        public string? EstadoAuditoria { get; set; }
        public DateTime FechaAuditoria { get; set; }
        [MaxLength(50)]
        public string? UsuarioAuditoria { get; set; }
    }
}
