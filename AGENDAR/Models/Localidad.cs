using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{ 
    public class Localidad
        
    {
        [Key]
        public int LocalidadID { get; set; }

        public string Descripcion { get; set; }

        public int ProvinciaID { get; set; }
        public string CodPostal { get; set; }

        public bool Eliminado { get; set; }
        public int EmpresaID { get; set; }

        public virtual Provincia Provincias { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
        //public virtual ICollection<Turno> Turnos { get; set; }

    }
    // Creamos un Nuevo OBJETO para MOSTRAR las Provincias en la tabla de Localidades
    public class LocalidadMostrar
    {

        public int LocalidadID { get; set; }

        public string CodPostal { get; set; }

        public string Descripcion { get; set; }

        public int ProvinciaID { get; set; }

        public string ProvinciaNombre { get; set; }

        public bool Eliminado { get; set; }
    }
}
