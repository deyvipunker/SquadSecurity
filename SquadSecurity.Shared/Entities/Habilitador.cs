using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class Habilitador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoDimension { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoDominio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoCriterio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoLineamiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoImprescindible { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(400, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoTipoSolucion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoResponsable { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(400, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string DescripcionActividad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoAmbienteCapturaE { get; set; }

        public int? CodigoEtapaCaptura { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CodigoEstadoCumplimiento { get; set; }

        public int? IdExcepcion { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? CodigoPlanAccion { get; set; }

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
