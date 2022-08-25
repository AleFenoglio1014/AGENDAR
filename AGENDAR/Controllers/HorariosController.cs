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
    [Authorize(Roles = "SuperUsuario, AdministradorEmpresa")]
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        //TRAEMOS EL METODO DESDE EL CONTROLADOR DE EMPRESAS PARA BUSCAR USUARIO Y EMPRESA ACTUAL.
        //SI HAY QUE MODIFICAR ALGO, SOLO SE HACE EN EL CONTROLADOR DE EMPRESA
        //public EmpresasController EmpresasController;
        public HorariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager/*, *//*EmpresasController empresasController*/)
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
            return View(await _context.Horario.ToListAsync());
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
                    HorarioCompleto = horario.HorarioCompleto,
                    TiempoTurnos = horario.TiempoTurnos
                };
                listadohorario.Add(horarioMostrar);
            }

            return Json(listadohorario);
        }

        // Funcion Guardar y Editar los Horarios
        [Authorize(Roles = "AdministradorEmpresa, SuperUsuario")]
        public JsonResult GuardarHorario(DateTime HoraInicio, DateTime HoraFin, int TiempoTurnos)
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            int resultado = 0;
            //// Si es 0 es CORRECTO 
            //// Si es 1 el Campo Descripcion esta VACIO
            //// Si es 2 el Registro YA EXISTE con la misma Descripcion

            int tiempoMostrar = 15;
            //if (TiempoTurnos == 0)
            //{
            //    tiempoMostrar = 15;
            //}
            if (TiempoTurnos == 1)
            {
                tiempoMostrar = 30;
            }
            if (TiempoTurnos == 2)
            {
                tiempoMostrar = 45;
            }
            if (TiempoTurnos == 3)
            {
                tiempoMostrar = 60;
            }
          
                //    // Antes de CREAR el registro debemos preguntar si existe una Horario igual
                if (_context.Horario.Any(e => e.HoraInicio == HoraInicio && e.HoraFin == HoraFin && e.TiempoTurnos == TiempoTurnos))
                {
                    resultado = 2;
                }
                else
                {
                    // Aca va a ir el codigo para CREAR un Horario

                    //CALCULAMOS LAS HORAS QUE TRABAJA LA EMPRESA
                     int horasDeTrabajo = HoraFin.Hour - HoraInicio.Hour;
                    //PASAMOS LAS HORAS QUE TRABAJA LA EMPRESA A MINUTOS
                    int minutosDiarios = horasDeTrabajo * 60; 


                    /*int minutosTurnos = TiempoTurnos;*/ // Tiempo de Duración de los Turnos en Minutos

                    int cantidadTurnos = minutosDiarios / tiempoMostrar;

                    DateTime fechaApertura = Convert.ToDateTime("01/07/2022");
                    fechaApertura = fechaApertura.AddHours(HoraInicio.Hour); // Horario de Apertura de la Empresa 7:00 a.m.
                    //Creamos un foreach donde reccorremos la cantidad de turnos y le vamos sumando el tiempo de cada turno
                    for (int i = 0; i < cantidadTurnos; i++)
                    {
                        // Para eso creamos un objeto de tipo nuevoHorario con los datos necesarios
                        var nuevoHorario = new Horario
                        {
                            HoraInicio = fechaApertura,
                            HoraFin = fechaApertura.AddMinutes(tiempoMostrar),
                            TiempoTurnos = tiempoMostrar
                        };
                        _context.Add(nuevoHorario);
                        _context.SaveChanges();

                        fechaApertura = fechaApertura.AddMinutes(tiempoMostrar);
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
