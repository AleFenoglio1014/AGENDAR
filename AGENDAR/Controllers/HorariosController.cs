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
    [Authorize]
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HorariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

        public async Task<IActionResult> Index()
        {
            return View(await _context.Horario.ToListAsync());
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            empresaUsuarioActual = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        }

        // Funcion para Completar la Tabla de Horario
        public JsonResult BuscarHorarios()
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var horarios = _context.Horario.ToList();
            List<HorarioMostrar> listadohorario = new List<HorarioMostrar>();

            foreach (var horario in horarios)

            {
                var horarioMostrar = new HorarioMostrar
                {
                    HorarioID = horario.HorarioID,
                    HoraInicio = horario.HoraInicio,
                    HoraIniciostring = horario.HoraInicio.ToString("HH:mm"),
                    HoraFin = horario.HoraFin,
                    HoraFinstring = horario.HoraFin.ToString("HH:mm"),
                };
                listadohorario.Add(horarioMostrar);
            }

            return Json(listadohorario);
        }
        // Funcion Guardar y Editar los Horarios
        public JsonResult GuardarHorario(int HorarioID, DateTime HoraInicio, DateTime HoraFin)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (HorarioID == 0)
            {
                // Antes de CREAR el registro debemos preguntar si existe una Horario igual
                if (_context.Horario.Any(e => e.HoraInicio == HoraInicio && e.HoraFin == HoraFin))
                {
                    resultado = 2;
                }
                else
                {
                    // Aca va a ir el codigo para CREAR un Horario
                    // Para eso creamos un objeto de tipo horarionuevo con los datos necesarios
                    var horarionuevo = new Horario
                    {
                        HoraInicio = HoraInicio,
                        HoraFin = HoraFin
                    };
                    _context.Add(horarionuevo);
                    _context.SaveChanges();
                }

            }
            else
            {
                // Antes de EDITAR el registro debemos preguntar si existe una Horario igual
                if (_context.Horario.Any(e => e.HoraInicio == HoraInicio && e.HoraFin == HoraFin && e.HorarioID != HorarioID))
                {
                    resultado = 2;
                }
                else
                {
                    // Aca va a ir el codigo para EDITAR un horario
                    // Buscamos el registro en la Base de Datos
                    var horario = _context.Horario.Single(m => m.HorarioID == HorarioID);
                    // Cambiamos los horarios por la que ingreso el Usuario en la Vista
                    horario.HoraInicio = HoraInicio;
                    horario.HoraFin = HoraFin;
                    _context.SaveChanges();
                }

            }            
                return Json(resultado);
            
        }

        // Funcion para Buscar el horarip
        public JsonResult BuscarHorario(int HorarioID)
        {
            var horario = _context.Horario.FirstOrDefault(m => m.HorarioID == HorarioID);

            return Json(horario);
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
