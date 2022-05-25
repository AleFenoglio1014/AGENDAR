using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Profesional
    {
        public int ProfesionalID { get; set; }

        public string Descripcion { get; set; }

        public virtual ClasificacionProfesional ClasificacionProfesionales { get; set; }

        public virtual Empresa Empresas { get; set; }

    }
}
