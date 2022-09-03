using AGENDAR.Data;
using AGENDAR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGENDAR.Controllers
{
    public class TurnosController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public TurnosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            empresaUsuarioActual = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        }
      
        public IActionResult IndexHomePublico()
        {
            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(p => p.Descripcion), "ProvinciaID", "Descripcion");

            List<Localidad> localidades = new List<Localidad>();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");


            List<Empresa> empresa = new List<Empresa>();
            empresa.Add(new Empresa { EmpresaID = 0, RazonSocial = "[SELECCIONE UNA EMPRESA]" });
            ViewBag.EmpresaID = new SelectList(empresa.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");


            var profesional = _context.Profesional.ToList();
            //List<Profesional> profesional = new List<Profesional>();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[SELECCIONE UN PROFESIONAL]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

            var horario = _context.Horario.ToList();
            //List<Horario> horario = new List<Horario>();
            //horario.Add(new Horario { HorarioID = 0, HoraInicio = "[SELECCIONE UN HORARIO]" });
            ViewBag.HorarioID = new SelectList(horario.OrderBy(p => p.HorarioCompleto), "HorarioID", "HorarioCompleto");

            return View();
            

        }
        [Authorize]
        public IActionResult Index()
        {
            return View();

        }



        public JsonResult BuscarTurnos()
        {
            var turnos = _context.Turnos.Include(r => r.Horarios).Include(r => r.Horarios.Profesionales).Include(r => r.Horarios.Profesionales.Empresas).Include(r => r.Horarios.Profesionales.Empresas.Localidades).Include(r => r.Horarios.Profesionales.Empresas.Localidades.Provincias).ToList();

            List<TurnoMostrar> listadoTurnoMostrar = new List<TurnoMostrar>();
            foreach (var turno in turnos)
            {
                var turnoMostrar = new TurnoMostrar()
                {
                    TurnoID = turno.TurnoID,
                    Nombre = turno.Nombre,
                    Apellido = turno.Apellido,
                    Telefono = turno.Telefono,
                    Email = turno.Email,
                    HorarioID = turno.HorarioID,
                    HorarioFecha = turno.Horarios.HorarioCompleto,
                    ProfesionalID = turno.Horarios.Profesionales.ProfesionalID,
                    ProfesionalNombre = turno.Horarios.Profesionales.ProfesionalNombreCompleto,
                    EmpresaID = turno.Horarios.Profesionales.Empresas.EmpresaID,
                    EmpresaNombre = turno.Horarios.Profesionales.Empresas.RazonSocial,
                    LocalidadID = turno.Horarios.Profesionales.Empresas.Localidades.LocalidadID,
                    LocalidadNombre = turno.Horarios.Profesionales.Empresas.Localidades.Descripcion,
                    ProvinciaID = turno.Horarios.Profesionales.Empresas.Localidades.Provincias.ProvinciaID,
                    ProvinciaNombre = turno.Horarios.Profesionales.Empresas.Localidades.Provincias.Descripcion,
                    

                };
                listadoTurnoMostrar.Add(turnoMostrar);
            }

            return Json(listadoTurnoMostrar);
        }



        //CODIGO PARA GUARDAR EL TURNO
        public JsonResult GuardarTurno(int TurnoID, string Nombre, string Apellido, string Email, Int64 Telefono,DateTime FechaTurno, int LocalidadID, int EmpresaID, int ProfesionalID, int ProvinciaID, int HorarioID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido) && EmpresaID != 0)
            {
                Nombre = Nombre.ToUpper();
                if (TurnoID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una TURNO existente
                    if (_context.Turnos.Any(e => e.Nombre == Nombre))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR un turno
                        // Para eso creamos un objeto de tipo turnoNuevo con los datos necesarios
                        var turnoNuevo = new Turno
                        {
                            Nombre = Nombre,
                            Apellido = Apellido,
                            Email = Email,
                            Telefono = Telefono,
                            FechaTurno = FechaTurno,
                            ProvinciaID = ProvinciaID,
                            LocalidadID = LocalidadID,
                            EmpresaID = EmpresaID,
                            ProfesionalID = ProfesionalID,
                            HorarioID = HorarioID,

                        };
                        _context.Add(turnoNuevo);
                        _context.SaveChanges();
                        Horario horario = _context.Horario.Find(turnoNuevo.HorarioID);
                        horario.Eliminado = true;
                        _context.SaveChanges();

                    }

                }

            }
            return Json(resultado);
        }
        private object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
