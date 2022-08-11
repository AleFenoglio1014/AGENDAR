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
              new ApplicationUser {
                UserName = "gonza.pagliano@gmail.com",
                NormalizedUserName = "GONZA.PAGLIANO@GMAIL.COM",
                Email = "gonza.pagliano@gmail.com",
                NormalizedEmail = "GONZA.PAGLIANO@GMAIL.COM",
            },
               new ApplicationUser {
                UserName = "valentinbeletti.29@gmail.com",
                NormalizedUserName = "VALENTINBELETTI.29@GMAIL.COM",
                Email = "valentinbeletti.29@gmail.com",
                NormalizedEmail = "VALENTINBELETTI.29@GMAIL.COM",
            },
                new ApplicationUser {
                UserName = "ale.1014f@gmail.com",
                NormalizedUserName = "ALE.1014F@GMAIL.COM",
                Email = "ale.1014f@gmail.com",
                NormalizedEmail = "ALE.1014F@GMAIL.COM",
            },

            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "agenDar.22");
            users[0].PasswordHash = passwordHasher.HashPassword(users[1], "123456");
            users[0].PasswordHash = passwordHasher.HashPassword(users[2], "123456");
            users[0].PasswordHash = passwordHasher.HashPassword(users[3], "123456");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "SuperUsuario").Id
            });
            
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "AdministradorEmpresa").Id
            });
            
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "AdministradorEmpresa").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[3].Id,
                RoleId = roles.First(q => q.Name == "AdministradorEmpresa").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
