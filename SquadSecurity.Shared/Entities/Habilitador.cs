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
        public int Codigo { get; set; }
        public int CodigoDimension { get; set; }
        public int CodigoDominio { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoCriterio { get; set; }
        public int CodigoLineamiento { get; set; }
        public int CodigoImpresindible { get; set; }
        public string Comentario { get; set; }
        public int CodigoTipoSolucion { get; set; }
        public int CodigoResponsable { get; set; }
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int CodigoAmbienteCapturaE { get; set; }
        public int CodigoEtapaCaptura { get; set; }
        public int CodigoEstadoCumplimiento { get; set; }
        public int IdExcepcion { get; set; }
        public string CodigoPlanAccion { get; set; }


        // AUDITORIA
        [MaxLength(10)]
        public string? EstadoAuditoria { get; set; }
        public DateTime FechaAuditoria { get; set; }
        [MaxLength(50)]
        public string? UsuarioAuditoria { get; set; }
    }
}
