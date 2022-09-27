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
using System.Threading;
using System.Globalization;

namespace AGENDAR.Controllers
{
   
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        
        public HorariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager/*, *//*EmpresasController empresasController*/)
        {
            _context = context;
            _userManager = userManager;
        }

        //Funcion para Buscar Empresa y Usuario
        public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        {
            var empresalogueada = _context.EmpresasUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
            empresaUsuarioActual.EmpresaID = empresalogueada.EmpresaID;

        }



        [Authorize]
        public IActionResult Index()
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);

            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-ROL QUE REGISTRO TIENE
            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DEL ROL PARA BUSCAR EN LA TABLA ROL, EL NOMBRE
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r => r.Name).FirstOrDefault();
            if (rolNombre == "SuperUsuario")
            {

                var empresaUsuario = (from e in _context.EmpresasUsuarios where e.UsuarioID == usuarioActual select e).Count();
                if (empresaUsuario == 0)
                {
                    return RedirectToAction("Index", "Empresas");
                }
            }


            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var profesional = _context.Profesional.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[TODOS LOS PROFESIONALES]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");
            ViewBag.ProfesionalIDFiltro = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

          
            return View();
        }
        public JsonResult ComboHorario(int id, string fecha)//HORARIO ID
        {
            //CAMBIAMOS A CULTURA ARGENTINA LA FECHA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Ar");

            var fechaTurno = Convert.ToDateTime(fecha);
            var nombreDia = fechaTurno.DayOfWeek;
            string numeroDia = Convert.ToString((int)nombreDia);

            //BUSCAR HORARIOS DE ACUERDO AL NUMEROS DEL DIA SELECCIONADO
            var horarios = (from o in _context.Horario where o.ProfesionalID == id && o.Eliminado == false select o).ToList();
            if (numeroDia == "0")
            {
                //Domingo
                horarios = (from o in horarios where o.Domingo == true select o).ToList();
            }
            if (numeroDia == "1")
            {
                //Lunes
                horarios = (from o in horarios where o.Lunes == true select o).ToList();
            }
            if (numeroDia == "2")
            {
                //Martes
                horarios = (from o in horarios where o.Martes == true select o).ToList();
            }
            if (numeroDia == "3")
            {
                //Miércoles
                horarios = (from o in horarios where o.Miercoles == true select o).ToList();
            }
            if (numeroDia == "4")
            {
                //Jueves
                horarios = (from o in horarios where o.Jueves == true select o).ToList();
            }
            if (numeroDia == "5")
            {
                //Viernes
                horarios = (from o in horarios where o.Viernes == true select o).ToList();
            }
            if (numeroDia == "6")
            {
                //Sábado
                horarios = (from o in horarios where o.Sabado == true select o).ToList();
            }

            List<Horario> horarioMostrar = new List<Horario>();
            // RECORREMOS TODOS LOS TURNOS DE ESE DIA
            foreach( var horario in horarios)
            {    // POR CADA HORARIO VAMOS A BUSCAR EN LA TABLA TURNO LO SIGUIENTE
                //SI EXISTE ALGUN TURNO AL MISMO DIA Y AL MISMO HORARIO ID
                var existeTurno = (from o in _context.Turnos where o.FechaTurno == fechaTurno && o.HorarioID == horario.HorarioID select o).Count();
            if(existeTurno == 0)
                {
                    horarioMostrar.Add(horario);
                }
            }

          

            return Json(new SelectList(horarioMostrar, "HorarioID", "HorarioCompleto"));
        }

        // Funcion para Completar la Tabla de Horario

        public JsonResult BuscarHorarios(int profesionalIDFiltro)
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var horarios = _context.Horario.Include(r => r.Profesionales).Where(l => l.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();

            if (profesionalIDFiltro > 0)
            {

                horarios = (from o in horarios where o.ProfesionalID == profesionalIDFiltro  select o).ToList();
            }
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
                    TiempoTurnos = horario.TiempoTurnos,
                    ProfesionalID = horario.Profesionales.ProfesionalID,
                    ProfesionalNombre = horario.Profesionales.ProfesionalNombreCompleto,
                    Eliminado = horario.Eliminado,
                    Lunes = horario.Lunes,
                    Martes = horario.Martes,
                    Miercoles = horario.Miercoles,
                    Jueves = horario.Jueves,
                    Viernes = horario.Viernes,
                    Sabado = horario.Sabado,
                    Domingo = horario.Domingo,
                };
                listadohorario.Add(horarioMostrar);
            }

            return Json(listadohorario);
        }
        // Funcion Guardar y Editar los Horarios

        public JsonResult GuardarHorario(DateTime HoraInicio, DateTime HoraFin, int TiempoTurnos, int ProfesionalID, bool Lunes, bool Martes, bool Miercoles, bool Jueves, bool Viernes, bool Sabado, bool Domingo)
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            int resultado = 0;
            //// Si es 0 es CORRECTO 
            //// Si es 1 el Campo  esta VACIO
            //// Si es 2 el Registro YA EXISTE con la misma Descripcion

           
            if (HoraInicio != null && HoraFin != null )
            {
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
                if (_context.Horario.Any(e => e.HoraInicio == HoraInicio && e.HoraFin == HoraFin  && e.ProfesionalID == ProfesionalID))
                {
                    resultado = 2;
                }
                if (HoraInicio > HoraFin)
                {
                    resultado = 3;
                }
                else
                {

                    // Aca va a ir el codigo para CREAR un Horario

                    //CALCULAMOS LAS HORAS QUE TRABAJA LA EMPRESA
                    int horasDeTrabajo = HoraFin.Hour - HoraInicio.Hour;
                    if (horasDeTrabajo < 1)
                    {
                        resultado = 4;
                    }
                    //PASAMOS LAS HORAS QUE TRABAJA LA EMPRESA A MINUTOS
                    int minutosDiarios = horasDeTrabajo * 60;


                    /*int minutosTurnos = TiempoTurnos;*/ // Tiempo de Duración de los Turnos en Minutos

                    int cantidadTurnos = minutosDiarios / tiempoMostrar;

                    DateTime fechaApertura = DateTime.Now;
                    fechaApertura = fechaApertura.AddHours(HoraInicio.Hour); // Horario de Apertura de la Empresa 7:00 a.m.
                    //Creamos un foreach donde reccorremos la cantidad de turnos y le vamos sumando el tiempo de cada turno
                    for (int i = 0; i < cantidadTurnos; i++)
                    {
                        // Para eso creamos un objeto de tipo nuevoHorario con los datos necesarios
                        var nuevoHorario = new Horario
                        {
                            HoraInicio = fechaApertura,
                            HoraFin = fechaApertura.AddMinutes(tiempoMostrar),
                            TiempoTurnos = tiempoMostrar,
                            ProfesionalID = ProfesionalID,
                            EmpresaID = empresaUsuarioActual.EmpresaID,
                            Lunes = Lunes,
                            Martes = Martes,
                            Miercoles = Miercoles,
                            Jueves = Jueves,
                            Viernes = Viernes,
                            Sabado = Sabado,
                            Domingo = Domingo


                        };
                        _context.Add(nuevoHorario);
                        _context.SaveChanges();

                        fechaApertura = fechaApertura.AddMinutes(tiempoMostrar);
                    }
                }
            }
            else
            {

                resultado = 1;
            }
            return Json(resultado);
            }
       

        // Funcion para Buscar el horario
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
