﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
    public class ClasificacionEmpresa
    {
        public int ClasificacionEmpresaID { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}
