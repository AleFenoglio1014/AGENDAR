using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Turno
    {
        [Key]
        public int TurnoID { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string UsuarioNombreCompleto
        {
            get
            {
                return string.Format("{0} {1} ", Nombre, Apellido);
            }
        }
        public string Email { get; set; }

        public Int64 Telefono { get; set; }

       
        public int LocalidadID { get; set; }
        
        public int EmpresaID { get; set; }
     
        public int ProfesionalID { get; set; }
        public int ProvinciaID { get; set; }
        public int HorarioID { get; set; }
        public DateTime FechaTurno { get; set; }
        [NotMapped]
        public string FechaTurnostring { get { return FechaTurno.ToString("dd/MM/yyyy"); } }

        public int Estado { get; set; }
        public virtual Horario Horarios { get; set; }

    }
   
    public class TurnoMostrar
    {

        public int TurnoID { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string UsuarioNombreCompleto { get; set; }
        public string Email { get; set; }
        public Int64 Telefono { get; set; }
        public int ProvinciaID { get; set; }
        public string ProvinciaNombre { get; set; }
        public int LocalidadID { get; set; }
        public string LocalidadNombre { get; set; }
      
        public int EmpresaID { get; set; }
        public string EmpresaNombre { get; set; }
        public int ProfesionalID { get; set; }
        public string ProfesionalNombre { get; set; }

        public DateTime FechaTurno { get; set; }
        public string FechaTurnostring { get; set; }
        public int Estado { get; set; }
        public int HorarioID { get; set; }
        public string HorarioCompleto { get; set; }
        public string HorarioFecha { get; set; }

     
    }
}
