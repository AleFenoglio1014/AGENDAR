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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AGENDAR.Controllers
{
   

    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmpresasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Empresas
        [Authorize(Roles = "SuperUsuario")]
        public IActionResult Index()
        {
            var localidades = _context.Localidad.Where(p => p.Eliminado == false).ToList();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");

           
            return View();
           
        }
      
        public IActionResult Create()
        {
            var localidades = _context.Localidad.Where(p => p.Eliminado == false).ToList();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");

          
            return View();
        }

        public IActionResult EmpresaIndex()
        {
          return View();
        }
        public JsonResult ComboEmpresa(int id)//EMPRESA ID
        {
            //BUSCAR EMPRESAS
            var empresas = (from o in _context.Empresa where o.LocalidadID == id && o.Eliminado == true select o).ToList();

            return Json(new SelectList(empresas, "EmpresaID", "RazonSocial"));
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            empresaUsuarioActual = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        }

        // Funcion para Completar la Tabla  de Empresas 
        [Authorize]
        public JsonResult BuscarEmpresas()
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var empresas = _context.Empresa.Include(r => r.Localidades).ToList();

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
                    ImagenEmpresa = empresa.ImagenEmpresa,
                    ImagenEmpresaString = Convert.ToBase64String(empresa.ImagenEmpresa),
                    Eliminado = empresa.Eliminado
                };
                listadoEmpresas.Add(empresasMostrar);
            }

            return Json(listadoEmpresas);
        }

        // Funcion Guardar y Editar las Empresa
        [Authorize]
        public async Task<JsonResult> GuardarEmpresa(int EmpresaID, string razonSocial, string cuit, string direccion, Int64 telefono, int LocalidadID , IFormFile archivo)
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //BUSCAR POR MEDIO DE CORREO ELECTRONICO ESE USUARIO CREADO PARA BUSCAR EL ID
            var usuario = _context.Users.Where(u => u.Id == usuarioActual).SingleOrDefault();

            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (usuario != null)
            {
                if (!string.IsNullOrEmpty(razonSocial))
                {
                    byte[] img = null;
                    string tipoImg = null;

                    if (archivo != null)
                    {
                        if (archivo.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                archivo.CopyTo(ms);
                                img = ms.ToArray();
                                tipoImg = archivo.ContentType;
                            }
                        }
                    }
                    razonSocial = razonSocial.ToUpper();

                    if (EmpresaID == 0)
                    {
                        // Antes de CREAR el registro debemos preguntar si existe una Empresa con la misma Descripcion
                        if (_context.Empresa.Any(e => e.RazonSocial == razonSocial && e.LocalidadID == LocalidadID))
                        {
                            resultado = 2;
                        }
                        else
                        {
                            // Aca va a ir el codigo para CREAR una Empresa
                            // Para eso creamos un objeto de tipo empresaNueva con los datos necesarios
                            var empresaNueva = new Empresa
                            {
                                RazonSocial = razonSocial,
                                CUIT = cuit,
                                Direccion = direccion,
                                Telefono = telefono,
                                LocalidadID = LocalidadID,
                                ImagenEmpresaString = tipoImg,
                                ImagenEmpresa = img
                            };
                            _context.Add(empresaNueva);
                            _context.SaveChanges();

                            //CREAMOS UN OBJETO DONDE NOS RELACIONA EL USUARIO CON LA EMPRESA PARA TENER REGISTRO EN LA TABLA
                            var empresaUsuario = new EmpresaUsuario
                            {
                                UsuarioID = usuarioActual,
                                EmpresaID = empresaNueva.EmpresaID
                            };
                            _context.Add(empresaUsuario);
                            _context.SaveChanges();

                            //ASIGNAMOS AL USUARIO QUE CREA LA EMPRESA EL ROL DE ADMINISTRADOREMPRESA
                            await _userManager.AddToRoleAsync(usuario, "AdministradorEmpresa");
                        }
                    }
                    else
                    {
                        // Antes de EDITAR el registro debemos preguntar si existe una Empresa con la misma Razon Social
                        if (_context.Empresa.Any(e => e.RazonSocial == razonSocial && e.EmpresaID != EmpresaID))
                        {
                            resultado = 2;
                        }
                        else
                        {
                            // Aca va a ir el codigo para EDITAR una Empresa
                            // Buscamos el registro en la Base de Datos
                            var empresa = _context.Empresa.Single(m => m.EmpresaID == EmpresaID);
                            // Cambiamos la RazonSocial por la que ingreso el Usuario en la Vista
                            empresa.RazonSocial = razonSocial;
                            empresa.CUIT = cuit;
                            empresa.Direccion = direccion;
                            empresa.Telefono = telefono;
                            empresa.LocalidadID = LocalidadID;
                            if (tipoImg != null)
                            {
                                empresa.ImagenEmpresaString = tipoImg;
                                empresa.ImagenEmpresa = img;
                            }
                            _context.SaveChanges();
                        }

                    }
                }
                else
                {
                    resultado = 1;
                }
               
            }
            return Json(resultado);
        }
        [Authorize(Roles = "SuperUsuario")]
        // Funcion para Buscar la empresa
        public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.FirstOrDefault(m => m.EmpresaID == EmpresaID);

            return Json(empresa);
        }

        //Desactivar Empresa
        [Authorize(Roles = "SuperUsuario")]
        public JsonResult DesactivarEmpresa(int EmpresaID, int Elimina)
        {
            bool resultado = true;

            var empresa = _context.Empresa.Find(EmpresaID);
            if (empresa != null)
            {
                if (Elimina == 0)
                {
                    empresa.Eliminado = true;
                }
                else
                {
                    empresa.Eliminado = false;
                }
                //_context.Empresa.Remove(empresa);
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
