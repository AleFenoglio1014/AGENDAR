using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AGENDAR.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "SuperUsuario", NormalizedName = "SUPERUSUARIO"},
                new IdentityRole { Name = "AdministradorEmpresa", NormalizedName = "ADMINISTRADOREMPRESA"},
                new IdentityRole { Name = "Usuario", NormalizedName = "USUARIO"},
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<ApplicationUser> users = new List<ApplicationUser>()
            { new ApplicationUser {
                UserName = "turnosagendar@gmail.com",
                NormalizedUserName = "TURNOSAGENDAR@GMAIL.COM",
                Email = "turnosagendar@gmail.com",
                NormalizedEmail = "TURNOSAGENDAR@GMAIL.COM",
            }, 
            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "123456");
            
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "SuperUsuario").Id
            });
           
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
