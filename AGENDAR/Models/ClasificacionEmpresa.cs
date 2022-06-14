using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class ClasificacionEmpresa
    {
        [Key]
        public int ClasificacionEmpresaID { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
       

    }
}
