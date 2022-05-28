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
    }
}
