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
    [Authorize]

    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public EmpresasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public EmpresasController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        //Funcion para Guardar Usuario Completo
        public async Task<JsonResult> GuardarUsuarioCompleto(string Email, string Password)
        {
            //var email = "usuario@gmail.com";
            //var password = "123456";

            //CREAR LA VARIABLE USUARIO CON TODOS LOS DATOS
            var usuarioCrear = new IdentityUser
            { 
                UserName = Email,
                Email = Email 
            };
            //EJECUTAR EL METODO CREAR USUARIO PASANDO COMO PARAMETRO EL OBJETO CREADO ANTERIORMENTE Y LA CONTRASEÑA DE INGRESO
            var result = await _userManager.CreateAsync(usuarioCrear, Password);

            //BUSCAR POR MEDIO DE CORREO ELECTRONICO ESE USUARIO CREADO PARA BUSCAR EL ID
            var usuario = _context.Users.Where(u => u.Email == Email).SingleOrDefault();

            //BUSCAMOS EL ROL DE ADMINISTRADOR EMPRESA PARA ASIGNAR A ESE USUARIO
            var rol = _context.Roles.Where(u => u.Name == "AdministradorEmpresa").SingleOrDefault();

            if (usuario != null && rol != null)
            {
                //EJECUTAMOS EL METODO DE AGREGAR EL ROL PARA ESE USUARIO
                await _userManager.AddToRoleAsync(usuario, rol.Id);


                //LUEGO EL CODIGO DE REGISTRAR EMPRESA 

                //var empresaadministrador = new EmpresaUsuario()
                //{
                //    UsuarioID = usuario.Id,
                //    EmpresaID = Empresa
                //};
                //_context.Add(empresaadministrador);
                //_context.SaveChanges();
            }



            return Json(result.Succeeded);
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
        public IActionResult Create()
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
                    ImagenEmpresa = empresa.ImagenEmpresa,
                    ImagenEmpresaString = Convert.ToBase64String(empresa.ImagenEmpresa),
                    Eliminado = empresa.Eliminado
                  

                };
                listadoEmpresas.Add(empresasMostrar);
            }

            return Json(listadoEmpresas);
        }

   


        // Funcion Guardar y Editar las Empresa

        public JsonResult GuardarEmpresa(int EmpresaID, string razonSocial, string cuit, string direccion, Int64 telefono, int LocalidadID, int ClasificacionEmpresaID, IFormFile archivo)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

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
                            //string base64 = Convert.ToBase64String(img);
                            // act on the Base64 data
                        }
                    }
                }
                razonSocial = razonSocial.ToUpper();
                if (EmpresaID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una Empresa con la misma Descripcion
                    if (_context.Empresa.Any(e => e.RazonSocial == razonSocial && e.LocalidadID == LocalidadID ))
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
                            ClasificacionEmpresaID = ClasificacionEmpresaID,
                           ImagenEmpresaString = tipoImg
                        };
                        empresaNueva.ImagenEmpresa = img;
                        _context.Add(empresaNueva);
                        _context.SaveChanges();
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
                        empresa.ClasificacionEmpresaID = ClasificacionEmpresaID;
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
                return Json(resultado);
            }

        // Funcion para Buscar la empresa
        public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.FirstOrDefault(m => m.EmpresaID == EmpresaID);

            return Json(empresa);
        }
      

        //[AllowAnonymous]
        //public JsonResult BuscarUltimasEmpresas()
        //{
        //    List<EmpresasMostrar> listadoUltimasEmpresa = new List<EmpresasMostrar>();

        //    var empresa = _context.Empresa.Include(r => r.Localidades).ToList();

        //    foreach (var itemEmpresa in empresa)
        //    {

        //        var empresas = new EmpresasMostrar()
        //        {
        //            EmpresaID = itemEmpresa.EmpresaID,
        //            RazonSocial = itemEmpresa.RazonSocial,
        //            LocalidadID = itemEmpresa.LocalidadID,
        //            LocalidadNombre = itemEmpresa.Localidades.Descripcion,
        //            ImagenEmpresaString = Convert.ToBase64String(itemEmpresa.ImagenEmpresa)

        //        };
        //        listadoUltimasEmpresa.Add(empresas);
        //    }
        //    JsonResult resultado = Json(listadoUltimasEmpresa);

        //    return resultado;
        //}
        //Eliminar Empresa

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
