using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class RevisionDet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoCabecera { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoIniciativa { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoHabilitador { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoSquad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Entregable { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoEstadoCumplimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoExcepcion { get; set; }

        public int? Comentario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string EstadoAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string UsuarioAuditoria { get; set; }
    }
}
