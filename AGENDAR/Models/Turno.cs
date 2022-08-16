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

        public string Email { get; set; }

        public Int64 Telefono { get; set; }

        public int ProvinciaID { get; set; }
        public int LocalidadID { get; set; }
        public int ClasificacionEmpresaID { get; set; }
        public int EmpresaID { get; set; }
        public int ClasificacionProfesionalID { get; set; }
        public int ProfesionalID { get; set; }
        public int HorarioID { get; set; }
        public DateTime FechaTurno { get; set; }
        public virtual Provincia Provincias { get; set; }
        public virtual Localidad Localidades { get; set; }
        public virtual ClasificacionEmpresa ClasificacionEmpresas { get; set; }
        public virtual Empresa Empresas { get; set; }
        public virtual ClasificacionProfesional GetClasificacionProfesionales { get; set; }
        public virtual Profesional Profesionales { get; set; }
        public virtual Horario Horarios { get; set; }

    }
   
    public class TurnoMostrar
    {

        public int TurnoID { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Int64 Telefono { get; set; }
        public int ProvinciaID { get; set; }
        public int LocalidadID { get; set; }
        public int ClasificacionEmpresaID { get; set; }
        public int EmpresaID { get; set; }
        public int ClasificacionProfesionalID { get; set; }
        public int ProfesionalID { get; set; }
        public int HorarioID { get; set; }

    }
}
