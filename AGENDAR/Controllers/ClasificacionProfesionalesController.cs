﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGENDAR.Data;
using AGENDAR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AGENDAR.Controllers
{
    [Authorize(Roles = "SuperUsuario")]

    public class ClasificacionProfesionalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        //TRAEMOS EL METODO DESDE EL CONTROLADOR DE EMPRESAS PARA BUSCAR USUARIO Y EMPRESA ACTUAL.
        //SI HAY QUE MODIFICAR ALGO, SOLO SE HACE EN EL CONTROLADOR DE EMPRESA
        //public EmpresasController EmpresasController;


        public ClasificacionProfesionalesController(ApplicationDbContext context, UserManager<IdentityUser> userManager/*, EmpresasController empresasController*/)
        {
            _context = context;
            _userManager = userManager;
            //EmpresasController = empresasController;
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            empresaUsuarioActual = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionProfesional.ToListAsync());
        }

        // Funcion para Completar la Tabla del Tipo de Profesional
        public JsonResult BuscarTipoProfesionales()
        {
            var tipoProfesional = _context.ClasificacionProfesional.ToList();

            return Json(tipoProfesional);
        }

        // Funcion Guardar y Editar las Actividades del profesional 
        [Authorize(Roles = "AdministradorEmpresa, SuperUsuario")]
        public JsonResult GuardarTipoProfesional(int ClasificacionProfesionalID, string Descripcion)
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (ClasificacionProfesionalID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una Actividad con la misma Descripcion
                    if (_context.ClasificacionProfesional.Any(e => e.Descripcion == Descripcion))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR una Actividad
                        // Para eso creamos un objeto de tipo actividadNueva con los datos necesarios
                        var actividadNueva = new ClasificacionProfesional
                        {
                            Descripcion = Descripcion
                        };
                        _context.Add(actividadNueva);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    // Antes de EDITAR el registro debemos preguntar si existe una Actividad con la misma Descripcion
                    if (_context.ClasificacionProfesional.Any(e => e.Descripcion == Descripcion && e.ClasificacionProfesionalID != ClasificacionProfesionalID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para EDITAR una Actividad
                        // Buscamos el registro en la Base de Datos
                        var tipoProfesional = _context.ClasificacionProfesional.Single(m => m.ClasificacionProfesionalID == ClasificacionProfesionalID);
                        // Cambiamos la Descripcion por la que ingreso el Usuario en la Vista
                        tipoProfesional.Descripcion = Descripcion;
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

        // Funcion para Buscar la Actividad
        public JsonResult BuscarTipoProfesional(int ClasificacionProfesionalID)
        {
            var tipoProfesional = _context.ClasificacionProfesional.FirstOrDefault(m => m.ClasificacionProfesionalID == ClasificacionProfesionalID);

            return Json(tipoProfesional);
        }

        private bool ClasificacionProfesionalExists(int id)
        {
            return _context.ClasificacionProfesional.Any(e => e.ClasificacionProfesionalID == id);
        }
    }
}
