using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class ClasificacionProfesional
    {
        [Key]
        public int ClasificacionProfesionalID { get; set; }

        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
      

        public virtual ICollection<Profesional> Profesionales { get; set; }
        //public virtual ICollection<Turno> Turnos { get; set; }

    }

}
