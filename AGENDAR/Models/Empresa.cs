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

        public int Telefono { get; set; }
        public bool Eliminado { get; set; }

        public virtual Localidad Localidades { get; set; }

        public virtual ClasificacionEmpresa ClasificacionEmpresas { get; set; }

        public virtual ICollection<Profesional> Profesionales { get; set; }
    }

    //public class EmpresasMostrar{

    //    public int EmpresaID { get; set; }
    //    public string RazonSocial { get; set; }
    //    public string CUIT { get; set; }
    //    public string Direccion { get; set; }
    //    public int Telefono { get; set; }
    //    public int LocalidadID { get; set; }
    //    public int ClasificacionEmpresaID { get; set; }
    //    public bool Eliminado { get; set; }

    //}
}
