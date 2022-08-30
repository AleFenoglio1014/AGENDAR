using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Horario
    {
        [Key]
        public int HorarioID { get; set; }

        public int EmpresaID { get; set; }
        public int ProfesionalID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        

        public int TiempoTurnos { get; set; }

        [NotMapped]
        public string HoraIniciostring { get { return HoraInicio.ToString("HH:mm"); } }

        [NotMapped]
        public string HoraFinstring { get { return HoraFin.ToString("HH:mm"); } }
       
        public virtual ICollection<Turno> Turnos { get; set; }
        public bool Eliminado { get; set; }

        public string HorarioCompleto
        {
            get
            {
                return string.Format("{0} - {1} ", HoraIniciostring, HoraFinstring);
            }
        }
       public virtual Profesional Profesionales { get; set; }
    }
    public class HorarioMostrar
    {
        public int HorarioID { get; set; }
        public DateTime HoraInicio { get; set; }
        public string HoraIniciostring { get; set; }
        public DateTime HoraFin { get; set; }
     
        
        public string HorarioCompleto { get; set; }
        public int ProfesionalID { get; set; }
        public string ProfesionalNombre { get; set; }
        public int TiempoTurnos { get; set; }
        public string HoraFinstring { get; set; }
        public bool Eliminado { get; set; }
    }

  
}
