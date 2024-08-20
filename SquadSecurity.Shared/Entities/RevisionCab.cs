using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class RevisionCab
    {
        public int Codigo { get; set; }
        public int CodigoSquad { get; set; }
        public int CodigoIniciativa { get; set; }
        public int CodigoAnalista { get; set; }
        public int CodigoArquitecto { get; set; }
        public int CodigoQuarter { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Comentario { get; set; }
        public string EstadoAuditoria { get; set; }
        public DateTime FechaAuditoria { get; set; }
        public string UsuarioAuditoria { get; set; }
    }
}
