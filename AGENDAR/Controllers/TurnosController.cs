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
            
           
            List<Empresa> empresa = new List<Empresa>();
            empresa.Add(new Empresa { EmpresaID = 0, RazonSocial = "[SELECCIONE UNA EMPRESA]" });
            ViewBag.EmpresaID = new SelectList(empresa.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");


            List<Profesional> profesional = new List<Profesional>();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[SELECCIONE UN PROFESIONAL]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");


            
           

            var horario = _context.Horario.Where(p => p.Eliminado == false).ToList();
            //List<Horario> horario = new List<Horario>();
            //horario.Add(new Horario { HorarioID = 0, HoraInicio = "[SELECCIONE UN HORARIO]" });
            ViewBag.HorarioID = new SelectList(horario.OrderBy(p => p.HorarioCompleto), "HorarioID", "HorarioCompleto");

            return View();
            

        }
        public IActionResult Index()
        {
            return View();

        }



        //public JsonResult BuscarTurnos()
        //{
        //    var turnos = _context.Turnos.Include(r => r.Profesionales)Include(r => r.Profesionales.Empresas).Include(r => r.Profesionales.Empresas.Localidades).Include(r => r.Profesionales.Empresas.Localidades.Provincias).Include(r => r.Horarios).ToList();

        //    List<TurnoMostrar> listadoTurnoMostrar = new List<TurnoMostrar>();
        //    foreach (var turno in turnos)
        //    {
        //        var turnoMostrar = new TurnoMostrar()
        //        {
        //            TurnoID = turno.TurnoID,
        //            Nombre = turno.Nombre,
        //            Apellido = turno.Apellido,
        //            Telefono = turno.Telefono,
        //            Email = turno.Email,
        //            ProfesionalID = turno.Profesionales.ProfesionalID,
        //            ProfesionalNombre = turno.Profesionales.ProfesionalNombreCompleto,
        //            EmpresaID = turno.Profesionales.Empresas.EmpresaID,
        //            EmpresaNombre = turno.Profesionales.Empresas.RazonSocial,
        //            LocalidadID = turno.Profesionales.Empresas.Localidades.LocalidadID,
        //            LocalidadNombre = turno.Profesionales.Empresas.Localidades.Descripcion,
        //            ProvinciaID = turno.Profesionales.Empresas.Localidades.Provincias.ProvinciaID,
        //            ProvinciaNombre = turno.Profesionales.Empresas.Localidades.Provincias.Descripcion,
        //            HorarioID = turno.HorarioID,
        //            HorarioFecha = turno.Horarios.HorarioCompleto

        //        };
        //        listadoTurnoMostrar.Add(turnoMostrar);
        //    }

        //    return Json(listadoTurnoMostrar);
        //}

        //CODIGO PARA GUARDAR EL TURNO
        //public JsonResult GuardarTurnoa(int ProvinciaID, string Descripcion)
        //{
        //    int resultado = 0;
        //    // Si es 0 es CORRECTO
        //    // Si es 1 el Campo Descripcion esta VACIO
        //    // Si es 2 el Registro YA EXISTE con la misma Descripcion

        //    if (!string.IsNullOrEmpty(Descripcion))
        //    {
        //        Descripcion = Descripcion.ToUpper();
        //        if (ProvinciaID == 0)
        //        {
        //            // Antes de CREAR el registro debemos preguntar si existe una Provincia con la misma Descripcion
        //            if (_context.Provincia.Any(e => e.Descripcion == Descripcion))
        //            {
        //                resultado = 2;
        //            }
        //            else
        //            {
        //                // Aca va a ir el codigo para CREAR una Provincia
        //                // Para eso creamos un objeto de tipo provinciaNueva con los datos necesarios
        //                var provinciaNueva = new Provincia
        //                {
        //                    Descripcion = Descripcion
        //                };
        //                _context.Add(provinciaNueva);
        //                _context.SaveChanges();
        //            }

        //        }

        //    }
        //    return Json(resultado);
        //}

    }
}
