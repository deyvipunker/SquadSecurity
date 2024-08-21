using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class SquadDetalle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoSquad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoIntegrante { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoAsignacion { get; set; }

        public int? Comentario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string? EstadoAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string? UsuarioAuditoria { get; set; }

        public int SquadId { get; set; }

        public Squad? Squad { get; set; }
    }
}
