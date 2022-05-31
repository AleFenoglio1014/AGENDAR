using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGENDAR.Data;
using AGENDAR.Models;

namespace AGENDAR.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public IActionResult Index()
        {
            var provincias = _context.Provincia.Where(p => p.Eliminado == false).ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(p => p.Descripcion), "ProvinciaID", "Descripcion");

            List<Localidad> localidad = new List<Localidad>();
            localidad.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });

            List<ClasificacionEmpresa> clasificacionEmpresas = new List<ClasificacionEmpresa>();
            clasificacionEmpresas.Add(new ClasificacionEmpresa { ClasificacionEmpresaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });

            ViewBag.ClasificacionEmpresaID = new SelectList(clasificacionEmpresas.OrderBy(p => p.Descripcion), "ClasificacionEmpresaID", "Descripcion");

            ViewBag.LocalidadID = new SelectList(localidad.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");

            return View();
        }

        // Funcion para Completar la Tabla  de Empresas 
        //public JsonResult BuscarEmpresas()
        //{
        //    var articulos = _context.Empresa.Include(r => r.Localidades).Include(p => p.Localidades.Provincias).ToList();
        //    List<EmpresasMostrar> listadoLocalidadesMostrar = new List<LocalidadMostrar>();
        //    foreach (var localidad in localidades)
        //    {
        //        var localidadMostrar = new LocalidadMostrar()
        //        {
        //            LocalidadID = localidad.LocalidadID,
        //            Descripcion = localidad.Descripcion,
        //            ProvinciaID = localidad.ProvinciaID,
        //            ProvinciaNombre = localidad.Provincias.Descripcion,
        //            Eliminado = localidad.Eliminado,

        //        };
        //        listadoLocalidadesMostrar.Add(localidadMostrar);
        //    }

        //    return Json(listadoLocalidadesMostrar);
        //}

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.EmpresaID == id);
        }
    }
}
