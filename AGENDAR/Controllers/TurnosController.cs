using AGENDAR.Data;
using Microsoft.AspNetCore.Mvc;
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

            return View();
        }
       

    //    // Funcion para Completar la Tabla  de Localidades 
    //    public JsonResult BuscarTurnos()
    //    {

    //        var turnos = _context.Turnos.Include(r => r.L).ToList();
    //        List<TurnoMostrar> listadoLocalidadesMostrar = new List<TurnoMostrar>();
    //        foreach (var localidad in localidades)
    //        {
    //            var localidadMostrar = new LocalidadMostrar()
    //            {
    //                LocalidadID = localidad.LocalidadID,
    //                Descripcion = localidad.Descripcion,
    //                CodPostal = localidad.CodPostal,
    //                ProvinciaID = localidad.ProvinciaID,
    //                ProvinciaNombre = localidad.Provincias.Descripcion,
    //                Eliminado = localidad.Eliminado

    //            };
    //            listadoLocalidadesMostrar.Add(localidadMostrar);
    //        }

    //        return Json(listadoLocalidadesMostrar);
    //    }

    }
}
