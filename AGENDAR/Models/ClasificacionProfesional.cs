using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class ClasificacionProfesional
    {
        public int ClasificacionProfesionalID { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Profesional> Profesionales { get; set; }
    }
}
