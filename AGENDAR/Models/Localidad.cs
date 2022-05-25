using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Localidad
    {
        public int LocalidadID { get; set; }

        public string Descripcion { get; set; }

        public string CodPostal { get; set; }

        public virtual Provincia Provincias { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}
