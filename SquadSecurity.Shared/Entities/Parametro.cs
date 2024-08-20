using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Entities
{
    public class Parametro
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Abreviatura { get; set; }
        public string EstadoAuditoria { get; set; }
        public DateTime FechaAuditoria { get; set; }
        public string UsuarioAuditoria { get; set; }
    }
}
