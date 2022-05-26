﻿using System;
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
    public class LocalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Localidades
        public IActionResult Index()
        {
            var provincias = _context.Provincia.Where(p => p.Eliminado == false).ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(p => p.Descripcion), "ProvinciaID", "Descripcion");
            return View();
        }
        public JsonResult ComboLocalidad(int id)//PROVINCIA ID
        {
            //BUSCAR LOCALIDADES
            var localidades = (from o in _context.Localidad where o.ProvinciaID == id && o.Eliminado == false select o).ToList();

            return Json(new SelectList(localidades, "LocalidadID", "Descripcion"));

        }
        // Funcion para Completar la Tabla  de Localidades 
        public JsonResult BuscarLocalidades()
        {
            var localidades = _context.Localidad.Include(r => r.Provincias).ToList();
            List<LocalidadMostrar> listadoLocalidadesMostrar = new List<LocalidadMostrar>();
            foreach (var localidad in localidades)
            {
                var localidadMostrar = new LocalidadMostrar()
                {
                    LocalidadID = localidad.LocalidadID,
                    Descripcion = localidad.Descripcion,
                    ProvinciaID = localidad.ProvinciaID,
                    ProvinciaNombre = localidad.Provincias.Descripcion,
                    Eliminado = localidad.Eliminado,

                };
                listadoLocalidadesMostrar.Add(localidadMostrar);
            }

            return Json(listadoLocalidadesMostrar);
        }
        // Funcion Guardar y Editar las Localidades

        public JsonResult GuardarLocalidad(int LocalidadID, string Descripcion, int ProvinciaID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (LocalidadID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una Localidad con la misma Descripcion
                    if (_context.Localidad.Any(e => e.Descripcion == Descripcion && e.ProvinciaID == ProvinciaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR una Localidad
                        // Para eso creamos un objeto de tipo localidadNueva con los datos necesarios
                        var localidadNueva = new Localidad
                        {
                            Descripcion = Descripcion,
                            ProvinciaID = ProvinciaID
                        };
                        _context.Add(localidadNueva);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    // Antes de EDITAR el registro debemos preguntar si existe una Localidad con la misma Descripcion
                    if (_context.Localidad.Any(e => e.Descripcion == Descripcion && e.LocalidadID != LocalidadID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para EDITAR una Localidad
                        // Buscamos el registro en la Base de Datos
                        var localidad = _context.Localidad.Single(m => m.LocalidadID == LocalidadID);
                        // Cambiamos la Descripcion por la que ingreso el Usuario en la Vista
                        localidad.Descripcion = Descripcion;
                        localidad.ProvinciaID = ProvinciaID;
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                if (_context.Localidad.Any(e => e.Descripcion == Descripcion && e.LocalidadID != LocalidadID))
                {
                    resultado = 1;
                }
                else
                {
                    var localidad = _context.Localidad.Single(m => m.LocalidadID == LocalidadID);
                    // Cambiamos la Descripcion por la que ingreso el Usuario en la Vista
                    localidad.Descripcion = Descripcion;
                    localidad.ProvinciaID = ProvinciaID;
                    _context.SaveChanges();
                }
            };


            return Json(resultado);
        }

        // Funcion para Buscar la Localidad
        public JsonResult BuscarLocalidad(int LocalidadID)
        {
            var localidad = _context.Localidad.FirstOrDefault(m => m.LocalidadID == LocalidadID);

            return Json(localidad);
        }

        // Funcion para Desactivar una Ciudad
        public JsonResult DesactivarLocalidad(int LocalidadID, int Elimina)
        {
            bool resultado = true;

            var localidad = _context.Localidad.Find(LocalidadID);
            if (localidad != null)
            {
                if (Elimina == 0)
                {
                    localidad.Eliminado = false;
                }
                else
                {
                    localidad.Eliminado = true;
                }
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidad.Any(e => e.LocalidadID == id);
        }
    }
}
