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
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Provincia.ToListAsync());
        }

        // Funcion para CompletarTablasProvincias 
        public JsonResult BuscarProvincias()
        {
            var provincias = _context.Provincia.ToList();

            return Json(provincias);
        }

        // Funcion Guardar y Editar las Provincias  
        public JsonResult GuardarProvincia(int ProvinciaID, string Descripcion)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (ProvinciaID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una Provincia con la misma Descripcion
                    if (_context.Provincia.Any(e => e.Descripcion == Descripcion))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR una Provincia
                        // Para eso creamos un objeto de tipo provinciaNueva con los datos necesarios
                        var provinciaNueva = new Provincia
                        {
                            Descripcion = Descripcion
                        };
                        _context.Add(provinciaNueva);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    // Antes de EDITAR el registro debemos preguntar si existe una Provincia con la misma Descripcion
                    if (_context.Provincia.Any(e => e.Descripcion == Descripcion && e.ProvinciaID != ProvinciaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para EDITAR una Provincia
                        // Buscamos el registro en la Base de Datos
                        var provincia = _context.Provincia.Single(m => m.ProvinciaID == ProvinciaID);
                        // Cambiamos la Descripcion por la que ingreso el Usuario en la Vista
                        provincia.Descripcion = Descripcion;
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                resultado = 1;
            };


            return Json(resultado);
        }
        // Funcion para Buscar la Provincia
        public JsonResult BuscarProvincia(int ProvinciaID)
        {
            var provincia = _context.Provincia.FirstOrDefault(m => m.ProvinciaID == ProvinciaID);

            return Json(provincia);
        }
        private bool ProvinciaExists(int id)
        {
            return _context.Provincia.Any(e => e.ProvinciaID == id);
        }
    }
}
