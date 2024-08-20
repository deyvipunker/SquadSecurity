using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class RevisionCab
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoSquad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoIniciativa { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoAnalista { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoArquitecto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoQuarter { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaFin { get; set; }

        public string? Comentario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string EstadoAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string UsuarioAuditoria { get; set; }
    }
}
