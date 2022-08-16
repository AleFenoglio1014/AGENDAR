using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }

        public string RazonSocial { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }

        public Int64 Telefono { get; set; }
        public bool Eliminado { get; set; }
        public byte[] ImagenEmpresa { get; set; }
        public string ImagenEmpresaString { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad Localidades { get; set; }
        public int ClasificacionEmpresaID { get; set; }
        public virtual ClasificacionEmpresa ClasificacionEmpresas { get; set; }

        public virtual ICollection<Profesional> Profesionales { get; set; }
        public virtual ICollection<Turno> Turnos { get; set; }
    }

    // Creamos un Nuevo OBJETO para MOSTRAR las Localidades y el tipo de empresa  en la tabla de Empresa
    public class EmpresasMostrar
    {

        public int EmpresaID { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public Int64 Telefono { get; set; }
        public int LocalidadID { get; set; }
        public string LocalidadNombre { get; set; }
        public byte[] ImagenEmpresa { get; set; }
        public string ImagenEmpresaString { get; set; }
        public int ClasificacionEmpresaID { get; set; }
        public string TipoEmpresa { get; set; }
        public bool Eliminado { get; set; }

    }
}
