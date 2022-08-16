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
                    Eliminado = horario.Eliminado
                };
                listadohorario.Add(horarioMostrar);
            }

            return Json(listadohorario);
        }

        // Funcion Guardar y Editar los Horarios
        [Authorize(Roles = "AdministradorEmpresa")]
        public JsonResult GuardarHorario(int HorarioID, DateTime HoraInicio, DateTime HoraFin)
        {
           
            int resultado = 0;
            //// Si es 0 es CORRECTO
            //// Si es 1 el Campo Descripcion esta VACIO
            //// Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (HorarioID == 0)
            {
                //    // Antes de CREAR el registro debemos preguntar si existe una Horario igual
                if (_context.Horario.Any(e => e.HoraInicio == HoraInicio && e.HoraFin == HoraFin))
                {
                    resultado = 2;
                }
                else
                {
                    // Aca va a ir el codigo para CREAR un Horario

                    int minutosDiarios = 840; //Tiempo en Minutos de 14 Horas
                    int minutosTurnos = 15; // Tiempo de Duración de los Turnos en Minutos

                    int cantidadTurnos = minutosDiarios / minutosTurnos;

                    DateTime fechaApertura = Convert.ToDateTime("01/07/2022");
                    fechaApertura = fechaApertura.AddHours(7); // Horario de Apertura de la Empresa 7:00 a.m.
                    //Creamos un foreach donde reccorremos la cantidad de turnos y le vamos sumando el tiempo de cada turno
                    for (int i = 0; i < cantidadTurnos; i++)
                    {
                        // Para eso creamos un objeto de tipo nuevoHorario con los datos necesarios
                        var nuevoHorario = new Horario
                        {
                            HoraInicio = fechaApertura,
                            HoraFin = fechaApertura.AddMinutes(minutosTurnos)
                        };
                        _context.Add(nuevoHorario);
                        _context.SaveChanges();

                        fechaApertura = fechaApertura.AddMinutes(minutosTurnos);
                    }
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
        public JsonResult DesactivarHorario(int HorarioID, int Elimina)
        {
            bool resultado = true;

            var horario = _context.Horario.Find(HorarioID);
            if (horario != null)
            {
                if (Elimina == 0)
                {
                    horario.Eliminado = false;
                }
                else
                {
                    horario.Eliminado = true;
                }
                _context.SaveChanges();
            }

            return Json(resultado);
        }
        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
