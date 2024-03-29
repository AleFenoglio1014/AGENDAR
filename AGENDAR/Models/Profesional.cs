﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Models
{
   
    public class Profesional
    {
        [Key]
        public int ProfesionalID { get; set; }
        public int EmpresaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ProfesionalNombreCompleto
        {
            get
            {
                return string.Format("{0} {1} ", Nombre, Apellido);
            }
        }

       
        
        public virtual Empresa Empresas { get; set; }
        public bool Eliminado { get; set; }
        //public virtual ICollection<Turno> Turnos { get; set; }
       public virtual ICollection<Horario> Horarios { get; set; }
    }
    // Creamos un Nuevo OBJETO para MOSTRAR el tipo de profesional  en la tabla de Profesional
    public class ProfesionalesMostrar
    {

        public int ProfesionalID { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ProfesionalNombreCompleto { get; set; }
        public int EmpresaID { get; set; }
        public string EmpresaNombre  { get; set; }
        public bool Eliminado { get; set; }

    }
}
