using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class Provincia
    {
        public int ProvinciaID { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public virtual ICollection<Localidad> Localidades { get; set; }

    }
}
