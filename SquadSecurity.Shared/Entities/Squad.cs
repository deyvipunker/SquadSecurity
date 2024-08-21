using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class Squad
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Tribu { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Negocio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoArquitecto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoAnalista { get; set; }

        public string? Comentario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string EstadoAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaAuditoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string UsuarioAuditoria { get; set; }

        public ICollection<SquadDetalle>? SquadDets { get; set; }
    }
}
