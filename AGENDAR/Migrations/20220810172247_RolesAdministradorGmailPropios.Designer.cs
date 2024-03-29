﻿// <auto-generated />
using System;
using AGENDAR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AGENDAR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220810172247_RolesAdministradorGmailPropios")]
    partial class RolesAdministradorGmailPropios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AGENDAR.Models.ClasificacionEmpresa", b =>
                {
                    b.Property<int>("ClasificacionEmpresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("ClasificacionEmpresaID");

                    b.ToTable("ClasificacionEmpresa");
                });

            modelBuilder.Entity("AGENDAR.Models.ClasificacionProfesional", b =>
                {
                    b.Property<int>("ClasificacionProfesionalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("ClasificacionProfesionalID");

                    b.ToTable("ClasificacionProfesional");
                });

            modelBuilder.Entity("AGENDAR.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CUIT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClasificacionEmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ImagenEmpresa")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImagenEmpresaString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalidadID")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.HasKey("EmpresaID");

                    b.HasIndex("ClasificacionEmpresaID");

                    b.HasIndex("LocalidadID");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("AGENDAR.Models.EmpresaUsuario", b =>
                {
                    b.Property<int>("EmpresaUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpresaUsuarioID");

                    b.ToTable("EmpresasUsuarios");
                });

            modelBuilder.Entity("AGENDAR.Models.Horario", b =>
                {
                    b.Property<int>("HorarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("HorarioID");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("AGENDAR.Models.Localidad", b =>
                {
                    b.Property<int>("LocalidadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("int");

                    b.HasKey("LocalidadID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Localidad");
                });

            modelBuilder.Entity("AGENDAR.Models.Profesional", b =>
                {
                    b.Property<int>("ProfesionalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClasificacionProfesionalID")
                        .HasColumnType("int");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesionalID");

                    b.HasIndex("ClasificacionProfesionalID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Profesional");
                });

            modelBuilder.Entity("AGENDAR.Models.Provincia", b =>
                {
                    b.Property<int>("ProvinciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinciaID");

                    b.ToTable("Provincia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "dcb8501d-f0fa-4770-89bf-38282a8cedf7",
                            ConcurrencyStamp = "ba4b43c6-fbd1-4c43-b638-e03856e1f234",
                            Name = "SuperUsuario",
                            NormalizedName = "SUPERUSUARIO"
                        },
                        new
                        {
                            Id = "a03459be-dcc8-4b9d-bc14-5d79546065fe",
                            ConcurrencyStamp = "94fba6d4-98ff-472f-8734-2b5bb2288f69",
                            Name = "AdministradorEmpresa",
                            NormalizedName = "ADMINISTRADOREMPRESA"
                        },
                        new
                        {
                            Id = "a3e369de-a130-4903-9846-53fa5c534e72",
                            ConcurrencyStamp = "2b7cc990-d771-4a80-a2a5-f8cfda975603",
                            Name = "Usuario",
                            NormalizedName = "USUARIO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "2a7bade7-cebb-4162-a264-9c08b9237816",
                            RoleId = "dcb8501d-f0fa-4770-89bf-38282a8cedf7"
                        },
                        new
                        {
                            UserId = "4f3059e0-b768-4be8-b0d0-98390f846674",
                            RoleId = "a03459be-dcc8-4b9d-bc14-5d79546065fe"
                        },
                        new
                        {
                            UserId = "68d89b0c-28d3-4a5e-8470-e08ac4eed153",
                            RoleId = "a03459be-dcc8-4b9d-bc14-5d79546065fe"
                        },
                        new
                        {
                            UserId = "38c44773-7cde-4db0-9bf5-568ceebdc20a",
                            RoleId = "a03459be-dcc8-4b9d-bc14-5d79546065fe"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AGENDAR.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "2a7bade7-cebb-4162-a264-9c08b9237816",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ce45b1a9-a3f3-408f-ad44-119808baa8bc",
                            Email = "turnosagendar@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TURNOSAGENDAR@GMAIL.COM",
                            NormalizedUserName = "TURNOSAGENDAR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEnkCZL3x59Kps1OT6GpBwmF1MUfw0AkcqaeEwcxBcz4EwAVrUBmtt/sV2Hsk2fFHA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7ab50eef-7850-4298-b12e-4464d8eec4a0",
                            TwoFactorEnabled = false,
                            UserName = "turnosagendar@gmail.com"
                        },
                        new
                        {
                            Id = "4f3059e0-b768-4be8-b0d0-98390f846674",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aabad448-f87d-482d-ad9a-ad9422197fa5",
                            Email = "gonza.pagliano@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GONZA.PAGLIANO@GMAIL.COM",
                            NormalizedUserName = "GONZA.PAGLIANO@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2707b167-25ae-456c-bb9d-0dfff78ddfb4",
                            TwoFactorEnabled = false,
                            UserName = "gonza.pagliano@gmail.com"
                        },
                        new
                        {
                            Id = "68d89b0c-28d3-4a5e-8470-e08ac4eed153",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a69882a8-3703-40cd-a60e-3bf3e49befce",
                            Email = "valentinbeletti.29@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "VALENTINBELETTI.29@GMAIL.COM",
                            NormalizedUserName = "VALENTINBELETTI.29@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e3041b24-30a4-4b60-bfdf-6778799b25f6",
                            TwoFactorEnabled = false,
                            UserName = "valentinbeletti.29@gmail.com"
                        },
                        new
                        {
                            Id = "38c44773-7cde-4db0-9bf5-568ceebdc20a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b5a4dcca-ea94-42b9-a4a8-946cbf309cfd",
                            Email = "ale.1014f@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALE.1014F@GMAIL.COM",
                            NormalizedUserName = "ALE.1014F@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7e60c560-435c-4eca-ac3e-c1a228f2f83f",
                            TwoFactorEnabled = false,
                            UserName = "ale.1014f@gmail.com"
                        });
                });

            modelBuilder.Entity("AGENDAR.Models.Empresa", b =>
                {
                    b.HasOne("AGENDAR.Models.ClasificacionEmpresa", "ClasificacionEmpresas")
                        .WithMany("Empresas")
                        .HasForeignKey("ClasificacionEmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AGENDAR.Models.Localidad", "Localidades")
                        .WithMany("Empresas")
                        .HasForeignKey("LocalidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGENDAR.Models.Localidad", b =>
                {
                    b.HasOne("AGENDAR.Models.Provincia", "Provincias")
                        .WithMany("Localidades")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGENDAR.Models.Profesional", b =>
                {
                    b.HasOne("AGENDAR.Models.ClasificacionProfesional", "ClasificacionProfesionales")
                        .WithMany("Profesionales")
                        .HasForeignKey("ClasificacionProfesionalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AGENDAR.Models.Empresa", "Empresas")
                        .WithMany("Profesionales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
