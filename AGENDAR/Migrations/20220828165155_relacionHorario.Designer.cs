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
    [Migration("20220828165155_relacionHorario")]
    partial class relacionHorario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AGENDAR.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CUIT")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfesionalID")
                        .HasColumnType("int");

                    b.Property<int>("TiempoTurnos")
                        .HasColumnType("int");

                    b.HasKey("HorarioID");

                    b.HasIndex("ProfesionalID");

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

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesionalID");

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

            modelBuilder.Entity("AGENDAR.Models.Turno", b =>
                {
                    b.Property<int>("TurnoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaTurno")
                        .HasColumnType("datetime2");

                    b.Property<int>("HorarioID")
                        .HasColumnType("int");

                    b.Property<int>("LocalidadID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfesionalID")
                        .HasColumnType("int");

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("int");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.HasKey("TurnoID");

                    b.HasIndex("HorarioID");

                    b.ToTable("Turnos");
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
                            Id = "7300519a-2919-4e3d-a78f-492fee8e0178",
                            ConcurrencyStamp = "ff465b77-9459-4667-a5ce-fc687c59279d",
                            Name = "SuperUsuario",
                            NormalizedName = "SUPERUSUARIO"
                        },
                        new
                        {
                            Id = "acc98425-3772-4620-abd9-12802ce4e8ed",
                            ConcurrencyStamp = "aa1adcfe-362a-4bec-ad56-d4cfd73bb427",
                            Name = "AdministradorEmpresa",
                            NormalizedName = "ADMINISTRADOREMPRESA"
                        },
                        new
                        {
                            Id = "cd8878e8-ef35-4a5f-bd52-1a4fb4d4b458",
                            ConcurrencyStamp = "a51fa9f0-2dff-4917-b6d6-cb4d01680edc",
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
                            UserId = "2890bc15-1888-4bc7-8e27-ab620ba25a48",
                            RoleId = "7300519a-2919-4e3d-a78f-492fee8e0178"
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
                            Id = "2890bc15-1888-4bc7-8e27-ab620ba25a48",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b148baf1-632e-462a-9923-8118f23b5e26",
                            Email = "turnosagendar@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TURNOSAGENDAR@GMAIL.COM",
                            NormalizedUserName = "TURNOSAGENDAR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAED+TEE1iWTIRZsEzsv4TjSEQuHUZeaxfS33rPaPtj18pPPDaVFDH+WfFBFfATxo8TA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0c0f6533-4605-4af0-863c-07a81e872b60",
                            TwoFactorEnabled = false,
                            UserName = "turnosagendar@gmail.com"
                        });
                });

            modelBuilder.Entity("AGENDAR.Models.Empresa", b =>
                {
                    b.HasOne("AGENDAR.Models.Localidad", "Localidades")
                        .WithMany("Empresas")
                        .HasForeignKey("LocalidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGENDAR.Models.Horario", b =>
                {
                    b.HasOne("AGENDAR.Models.Profesional", "Profesionales")
                        .WithMany("Horarios")
                        .HasForeignKey("ProfesionalID")
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
                    b.HasOne("AGENDAR.Models.Empresa", "Empresas")
                        .WithMany("Profesionales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AGENDAR.Models.Turno", b =>
                {
                    b.HasOne("AGENDAR.Models.Horario", "Horarios")
                        .WithMany("Turnos")
                        .HasForeignKey("HorarioID")
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
