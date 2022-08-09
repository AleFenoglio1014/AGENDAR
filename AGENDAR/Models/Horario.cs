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
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        [NotMapped]
        public string HoraInicioString { get { return HoraInicio.ToString("HH:mm"); } }
        [NotMapped]
        public string HoraFinString { get { return HoraFin.ToString("HH:mm"); } }
    }


}
    public class HorarioMostrar
    {
        public int HorarioID { get; set; }
        public DateTime HoraInicio { get; set; }
        public string HoraIniciostring { get; set; }
        public DateTime HoraFin { get; set; }
        public string HoraFinstring { get; set; }
    }

    
