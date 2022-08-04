using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AGENDAR.Models;

namespace AGENDAR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AGENDAR.Models.Provincia> Provincia { get; set; }
        public DbSet<AGENDAR.Models.Localidad> Localidad { get; set; }
        public DbSet<AGENDAR.Models.ClasificacionEmpresa> ClasificacionEmpresa { get; set; }
        public DbSet<AGENDAR.Models.ClasificacionProfesional> ClasificacionProfesional { get; set; }
        public DbSet<AGENDAR.Models.Empresa> Empresa { get; set; }
        public DbSet<AGENDAR.Models.Profesional> Profesional { get; set; }
        public DbSet<AGENDAR.Models.Horario> Horario { get; set; }
        public DbSet<AGENDAR.Models.EmpresaUsuario> EmpresasUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Seed();
            base.OnModelCreating(modelbuilder);
        }

    }
}
