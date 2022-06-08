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
            var localidades = _context.Localidad.Where(p => p.Eliminado == false).ToList();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");

            var clasificacionempresas = _context.ClasificacionEmpresa.Where(p => p.Eliminado == false).ToList();
            clasificacionempresas.Add(new ClasificacionEmpresa { ClasificacionEmpresaID = 0, Descripcion = "[SELECCIONE TIPO DE EMPRESA]" });
            ViewBag.ClasificacionEmpresaID = new SelectList(clasificacionempresas.OrderBy(p => p.Descripcion), "ClasificacionEmpresaID", "Descripcion");

            return View();
        }

        // Funcion para Completar la Tabla  de Empresas 
        public JsonResult BuscarEmpresas()
        {
            var empresas = _context.Empresa.Include(r => r.Localidades).Include(p => p.ClasificacionEmpresas).ToList();

            List<EmpresasMostrar> listadoEmpresas = new List<EmpresasMostrar>();
            
            foreach (var empresa in empresas)
            {
                var empresasMostrar = new EmpresasMostrar
                {
                    EmpresaID = empresa.EmpresaID,
                    RazonSocial = empresa.RazonSocial,
                    CUIT = empresa.CUIT,
                    Direccion = empresa.Direccion,
                    Telefono = empresa.Telefono,
                    LocalidadID = empresa.LocalidadID,
                    LocalidadNombre = empresa.Localidades.Descripcion,
                    ClasificacionEmpresaID = empresa.ClasificacionEmpresaID,
                    TipoEmpresa = empresa.ClasificacionEmpresas.Descripcion,
                    Eliminado = empresa.Eliminado
                  

                };
                listadoEmpresas.Add(empresasMostrar);
            }

            return Json(listadoEmpresas);
        }
   


        // Funcion Guardar y Editar las Empresa

        public JsonResult GuardarEmpresa(int EmpresaID, string RazonSocial, string CUIT, string Direccion, Int64 Telefono, int LocalidadID, int ClasificacionEmpresaID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(RazonSocial))
            {
                RazonSocial = RazonSocial.ToUpper();
                if (EmpresaID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una Empresa con la misma Descripcion
                    if (_context.Empresa.Any(e => e.RazonSocial == RazonSocial && e.LocalidadID == LocalidadID ))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para CREAR una Empresa
                        // Para eso creamos un objeto de tipo empresaNueva con los datos necesarios
                        var empresaNueva = new Empresa
                        {
                            RazonSocial = RazonSocial,
                            CUIT = CUIT,
                            Direccion = Direccion,
                            Telefono = Telefono,
                            LocalidadID = LocalidadID,
                            ClasificacionEmpresaID = ClasificacionEmpresaID

                        };
                        _context.Add(empresaNueva);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    // Antes de EDITAR el registro debemos preguntar si existe una Empresa con la misma Razon Social
                    if (_context.Empresa.Any(e => e.RazonSocial == RazonSocial && e.EmpresaID != EmpresaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // Aca va a ir el codigo para EDITAR una Empresa
                        // Buscamos el registro en la Base de Datos
                        var empresa = _context.Empresa.Single(m => m.EmpresaID == EmpresaID);
                        // Cambiamos la RazonSocial por la que ingreso el Usuario en la Vista
                        empresa.RazonSocial = RazonSocial;
                        empresa.CUIT = CUIT;
                        empresa.Direccion = Direccion;
                        empresa.Telefono = Telefono;
                        empresa.LocalidadID = LocalidadID;
                        empresa.ClasificacionEmpresaID = ClasificacionEmpresaID;
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                if (_context.Empresa.Any(e => e.RazonSocial == RazonSocial))
                {
                    resultado = 1;
                }
                else
                {
                    var empresa = _context.Empresa.Single(m => m.EmpresaID == EmpresaID);
                    // Cambiamos la RazonSocial por la que ingreso el Usuario en la Vista
                    empresa.RazonSocial = RazonSocial;
                    empresa.CUIT = CUIT;
                    empresa.Direccion = Direccion;
                    empresa.Telefono = Telefono;
                    empresa.LocalidadID = LocalidadID;
                    empresa.ClasificacionEmpresaID = ClasificacionEmpresaID;
                    _context.SaveChanges();
                }
            };


            return Json(resultado);
        }


        // Funcion para Buscar la empresa
        public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.FirstOrDefault(m => m.EmpresaID == EmpresaID);

            return Json(empresa);
        }


        //Eliminar Empresa

        public JsonResult EliminarEmpresa(int EmpresaID)
        {
            bool resultado = true;

            var empresa = _context.Empresa.Find(EmpresaID);
            if (empresa != null)
            {
                _context.Empresa.Remove(empresa);
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.EmpresaID == id);
        }
    }
}
