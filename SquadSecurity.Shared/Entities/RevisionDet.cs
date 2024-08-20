using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class RevisionDet
    {
        public int Codigo { get; set; }
        public int CodigoCabecera { get; set; }
        public int CodigoIniciativa { get; set; }
        public int CodigoHabilitador { get; set; }
        public int CodigoSquad { get; set; }
        public string Entregable { get; set; }
        public int CodigoEstadoCumplimiento { get; set; }
        public int CodigoExcepcion { get; set; }
        public int Comentario { get; set; }
        public string EstadoAuditoria { get; set; }
        public DateTime FechaAuditoria { get; set; }
        public string UsuarioAuditoria { get; set; }
    }
}
