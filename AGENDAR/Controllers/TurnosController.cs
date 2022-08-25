using AGENDAR.Data;
using AGENDAR.Models;
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

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexHomePublico()
        {
            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(p => p.Descripcion), "ProvinciaID", "Descripcion");

            List<Localidad> localidades = new List<Localidad>();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");


            var clasificacionempresas = _context.ClasificacionEmpresa.Where(p => p.Eliminado == false).ToList();
            clasificacionempresas.Add(new ClasificacionEmpresa { ClasificacionEmpresaID = 0, Descripcion = "[SELECCIONE TIPO DE EMPRESA]" });
            ViewBag.ClasificacionEmpresaID = new SelectList(clasificacionempresas.OrderBy(p => p.Descripcion), "ClasificacionEmpresaID", "Descripcion");

            List<Empresa> empresa = new List<Empresa>();
            empresa.Add(new Empresa { EmpresaID = 0, RazonSocial = "[SELECCIONE UNA EMPRESA]" });
            ViewBag.EmpresaID = new SelectList(empresa.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");

          

            var clasificacionprofesional = _context.ClasificacionProfesional.Where(p => p.Eliminado == false).ToList();
            clasificacionprofesional.Add(new ClasificacionProfesional { ClasificacionProfesionalID = 0, Descripcion = "[SELECCIONE TIPO DE PROFESIONAL]" });
            ViewBag.ClasificacionProfesionalID = new SelectList(clasificacionprofesional.OrderBy(p => p.Descripcion), "ClasificacionProfesionalID", "Descripcion");

            List<Profesional> profesional = new List<Profesional>();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[SELECCIONE UN PROFESIONAL]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

            List<Horario> horario = new List<Horario>();
            //horario.Add(new Horario { HorarioID = 0, HoraInicio = "[SELECCIONE UN HORARIO]" });
            ViewBag.HorarioID = new SelectList(horario.OrderBy(p => p.HorarioCompleto), "HorarioID", "HorarioCompleto");

            return View();
            

        }



        public JsonResult BuscarTurnos()
        {
            var turnos = _context.Turnos.Include(r => r.Profesionales).Include(r => r.Profesionales.ClasificacionProfesionales).Include(r => r.Profesionales.Empresas).Include(r => r.Profesionales.Empresas.ClasificacionEmpresas).Include(r => r.Profesionales.Empresas.Localidades).Include(r => r.Profesionales.Empresas.Localidades.Provincias).Include(r => r.Horarios).ToList();

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
                    ProfesionalID = turno.Profesionales.ProfesionalID,
                    ProfesionalNombre = turno.Profesionales.Nombre,
                    ClasificacionProfesionalID = turno.Profesionales.ClasificacionProfesionales.ClasificacionProfesionalID,
                    ClasificacionProfesionalNombre = turno.Profesionales.ClasificacionProfesionales.Descripcion,
                    EmpresaID = turno.Profesionales.Empresas.EmpresaID,
                    EmpresaNombre = turno.Profesionales.Empresas.RazonSocial,
                    ClasificacionEmpresaID = turno.Profesionales.Empresas.ClasificacionEmpresas.ClasificacionEmpresaID,
                    ClasificacionEmpresaNombre = turno.Profesionales.Empresas.ClasificacionEmpresas.Descripcion,
                    LocalidadID = turno.Profesionales.Empresas.Localidades.LocalidadID,
                    LocalidadNombre = turno.Profesionales.Empresas.Localidades.Descripcion,
                    ProvinciaID = turno.Profesionales.Empresas.Localidades.Provincias.ProvinciaID,
                    ProvinciaNombre = turno.Profesionales.Empresas.Localidades.Provincias.Descripcion,
                    HorarioID = turno.HorarioID,
                    HorarioFecha = turno.Horarios.HorarioCompleto

                };
                listadoTurnoMostrar.Add(turnoMostrar);
            }

            return Json(listadoTurnoMostrar);
        }

    }
}
