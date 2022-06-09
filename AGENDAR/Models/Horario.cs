using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Horario
    {
        [Key]
        public int HorarioID { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }


    }
    public class HorarioMostrar
    {
        public int HorarioID { get; set; }
        public DateTime HoraInicio { get; set; }
        public string HoraIniciostring { get; set; }
        public DateTime HoraFin { get; set; }
        public string HoraFinstring { get; set; }
    }
}
    
