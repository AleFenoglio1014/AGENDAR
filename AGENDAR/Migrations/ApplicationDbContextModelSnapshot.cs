﻿// <auto-generated />
using System;
using AGENDAR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AGENDAR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = "2356e511-0f58-4c46-9d32-5695f2e612ef",
                            ConcurrencyStamp = "942c657e-a216-4e6b-abd3-8226c6440fd4",
                            Name = "SuperUsuario",
                            NormalizedName = "SUPERUSUARIO"
                        },
                        new
                        {
                            Id = "691dea6d-05f1-4edd-a925-8623336c65e7",
                            ConcurrencyStamp = "065fad45-df7a-474f-925b-b2ed38fef182",
                            Name = "AdministradorEmpresa",
                            NormalizedName = "ADMINISTRADOREMPRESA"
                        },
                        new
                        {
                            Id = "1b123868-6f55-48bb-8632-b7959014601b",
                            ConcurrencyStamp = "4d4d8bfe-6589-462d-8188-f159929f47ac",
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
                            UserId = "19e507b4-da8b-4091-b36c-085e7ae602db",
                            RoleId = "2356e511-0f58-4c46-9d32-5695f2e612ef"
                        },
                        new
                        {
                            UserId = "65339865-ae2c-489b-8040-129f65a288e8",
                            RoleId = "691dea6d-05f1-4edd-a925-8623336c65e7"
                        },
                        new
                        {
                            UserId = "281aca7e-79b6-4712-ab5f-15448c3c17b5",
                            RoleId = "691dea6d-05f1-4edd-a925-8623336c65e7"
                        },
                        new
                        {
                            UserId = "ebd098c6-4d49-46d7-ac60-40ce5cf46717",
                            RoleId = "691dea6d-05f1-4edd-a925-8623336c65e7"
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
                            Id = "19e507b4-da8b-4091-b36c-085e7ae602db",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bf91f64f-7dfb-4503-8130-2ab3a8971ba2",
                            Email = "turnosagendar@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TURNOSAGENDAR@GMAIL.COM",
                            NormalizedUserName = "TURNOSAGENDAR@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHqFAslJlzcMxRSASW/0unIxlkousKabwnMme5BZrpSPdQ2e3Kphi+5tWbI4U4KJcQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b665282c-fe74-465e-a8fc-340d77fd9de5",
                            TwoFactorEnabled = false,
                            UserName = "turnosagendar@gmail.com"
                        },
                        new
                        {
                            Id = "65339865-ae2c-489b-8040-129f65a288e8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1c61ab91-dbbb-4129-b1a3-c491d3d1ad76",
                            Email = "gonza.pagliano@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GONZA.PAGLIANO@GMAIL.COM",
                            NormalizedUserName = "GONZA.PAGLIANO@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "659ec851-9e23-4f2b-bc54-3e8bd404ae1f",
                            TwoFactorEnabled = false,
                            UserName = "gonza.pagliano@gmail.com"
                        },
                        new
                        {
                            Id = "281aca7e-79b6-4712-ab5f-15448c3c17b5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "926fa877-8ea7-4cdf-b574-4b77ae007bb7",
                            Email = "valentinbeletti.29@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "VALENTINBELETTI.29@GMAIL.COM",
                            NormalizedUserName = "VALENTINBELETTI.29@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8e44fa41-5437-4f2d-932f-1df4867a9664",
                            TwoFactorEnabled = false,
                            UserName = "valentinbeletti.29@gmail.com"
                        },
                        new
                        {
                            Id = "ebd098c6-4d49-46d7-ac60-40ce5cf46717",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ee37e607-0a51-449e-8c4c-34716f5774ee",
                            Email = "ale.1014f@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALE.1014F@GMAIL.COM",
                            NormalizedUserName = "ALE.1014F@GMAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d933b1fd-1fc2-42a9-a0f1-399cf5c961e1",
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
