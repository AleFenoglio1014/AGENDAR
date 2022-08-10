using System;
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
    public class ProfesionalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProfesionalesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public ProfesionalesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Profesionales
        public IActionResult Index()
        {
            var empresa = _context.Empresa.Where(p => p.Eliminado == false).ToList();
            empresa.Add(new Empresa { EmpresaID = 0, RazonSocial = "[SELECCIONE UNA EMPRESA]" });
            ViewBag.EmpresaID = new SelectList(empresa.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");

            var clasificacionprofesional = _context.ClasificacionProfesional.Where(p => p.Eliminado == false).ToList();
            clasificacionprofesional.Add(new ClasificacionProfesional { ClasificacionProfesionalID = 0, Descripcion = "[SELECCIONE TIPO DE PROFESIONAL]" });
            ViewBag.ClasificacionProfesionalID = new SelectList(clasificacionprofesional.OrderBy(p => p.Descripcion), "ClasificacionProfesionalID", "Descripcion");

            return View();
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            empresaUsuarioActual = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        }

        // Funcion para Completar la Tabla  de Profesionales 

        public JsonResult BuscarProfesionales()
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var profesionales = _context.Profesional.Include(r => r.Empresas).Include(p => p.ClasificacionProfesionales).ToList();

            List<ProfesionalesMostrar> listadoProfesional = new List<ProfesionalesMostrar>();

            foreach (var profesional in profesionales)
            {
                var profesionalesMostrar = new ProfesionalesMostrar
                {
                    ProfesionalID = profesional.ProfesionalID,
                    Nombre = profesional.Nombre,
                    Apellido = profesional.Apellido,
                    ProfesionalNombreCompleto = profesional.ProfesionalNombreCompleto,
                    ClasificacionProfesionalID = profesional.ClasificacionProfesionalID,
                    TipoProfesional = profesional.ClasificacionProfesionales.Descripcion,
                    EmpresaID = profesional.EmpresaID,
                    EmpresaNombre = profesional.Empresas.RazonSocial,
                    Eliminado = profesional.Eliminado


                };
                listadoProfesional.Add(profesionalesMostrar);
            }

            return Json(listadoProfesional);
        }
        // Funcion Guardar y Editar los Porfesionales
        [Authorize(Roles = "AdministradorEmpresa, SuperUsuario")]
        public JsonResult GuardarProfesional(int ProfesionalID, string Nombre, string Apellido,  int EmpresaID, int ClasificacionProfesionalID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido))
            {
                Nombre = Nombre.ToUpper();
                Apellido = Apellido.ToUpper();
                if (ProfesionalID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe un Profesional con el mismo nombre y apellido
                    if (_context.Profesional.Any(e => e.Nombre == Nombre && e.Apellido == Apellido && e.EmpresaID == EmpresaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR un Profesional
                        // Para eso creamos un objeto de tipo profesionalNuevo con los datos necesarios
                        var profesionalNuevo = new Profesional
                        {
                            Nombre = Nombre,
                            Apellido = Apellido,
                            EmpresaID = EmpresaID,
                            ClasificacionProfesionalID = ClasificacionProfesionalID

                        };
                        _context.Add(profesionalNuevo);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    // Antes de EDITAR el registro debemos preguntar si existe un Profesional con el mismo nombre y apellido
                    if (_context.Profesional.Any(e => e.Nombre == Nombre && e.Apellido == Apellido && e.EmpresaID == EmpresaID && e.ProfesionalID != ProfesionalID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para EDITAR un Profesional
                        // Buscamos el registro en la Base de Datos
                        var profesional = _context.Profesional.Single(m => m.ProfesionalID == ProfesionalID);
                        // Cambiamos el nombre por la que ingreso el Usuario en la Vista
                        profesional.Nombre = Nombre;
                        profesional.Apellido = Apellido;
                        profesional.ClasificacionProfesionalID = ClasificacionProfesionalID;
                        profesional.EmpresaID = EmpresaID;
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                if (_context.Profesional.Any(e => e.Nombre == Nombre ))
                {
                    resultado = 1;
                }
                else
                {
                    var profesional = _context.Profesional.Single(m => m.ProfesionalID == ProfesionalID);
                    // Cambiamos el nombre por la que ingreso el Usuario en la Vista
                    profesional.Nombre = Nombre;
                    profesional.Apellido = Apellido;
                    profesional.ClasificacionProfesionalID = ClasificacionProfesionalID;
                    profesional.EmpresaID = EmpresaID;
                    _context.SaveChanges();
                }
            };


            return Json(resultado);
        }

        // Funcion para Buscar el Profesional
        public JsonResult BuscarProfesional(int ProfesionalID)
        {
            var profesional = _context.Profesional.FirstOrDefault(m => m.ProfesionalID == ProfesionalID);

            return Json(profesional);
        }
        //Eliminar Profesional

        public JsonResult Eliminarprofesional(int ProfesionalID)
        {
            bool resultado = true;

            var profesional = _context.Profesional.Find(ProfesionalID);
            if (profesional != null)
            {
                _context.Profesional.Remove(profesional);
                _context.SaveChanges();
            }

            return Json(resultado);
        }




        private bool ProfesionalExists(int id)
        {
            return _context.Profesional.Any(e => e.ProfesionalID == id);
        }
    }
}
