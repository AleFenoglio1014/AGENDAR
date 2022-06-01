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

        //COMENTARIO
        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public IActionResult Index()
        {
            var localidades = _context.Localidad.Where(p => p.Eliminado == false).ToList();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");

            var clasificacionempresas = _context.ClasificacionEmpresa.Where(p => p.Eliminado == false).ToList();
            clasificacionempresas.Add(new ClasificacionEmpresa { ClasificacionEmpresaID = 0, Descripcion = "[SELECCIONE TIPO DE EMPRESA]" });
            ViewBag.ClasificacionEmpresaID = new SelectList(clasificacionempresas.OrderBy(p => p.Descripcion), "ClasificacionEmpresaID", "Descripcion");

            return View();
        }

        // Funcion para Completar la Tabla  de Empresas 
        public JsonResult BuscarEmpresa()
        {
            var empresas = _context.Empresa.Include(r => r.Localidades).Include(p => p.ClasificacionEmpresas).ToList();
            List<EmpresasMostrar> listadoEmpresasMostrar = new List<EmpresasMostrar>();
            foreach (var empresa in empresas)
            {
                var empresasMostrar = new EmpresasMostrar()
                {
                    EmpresaID = empresa.EmpresaID,
                    RazonSocial = empresa.RazonSocial,
                    CUIT = empresa.CUIT,
                    Direccion = empresa.Direccion,
                    Telefono = empresa.Telefono,
                    LocalidadID = empresa.Localidades.LocalidadID,
                    LocalidadNombre = empresa.Localidades.Descripcion,
                    ClasificacionEmpresaID = empresa.ClasificacionEmpresas.ClasificacionEmpresaID,
                    TipoEmpresa = empresa.ClasificacionEmpresas.Descripcion,
                    Eliminado = empresa.Eliminado

                };
                listadoEmpresasMostrar.Add(empresasMostrar);
            }

            return Json(listadoEmpresasMostrar);
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

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.EmpresaID == id);
        }
    }
}
