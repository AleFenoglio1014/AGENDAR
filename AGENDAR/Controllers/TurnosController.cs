using AGENDAR.Data;
using AGENDAR.Migrations;
using AGENDAR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AGENDAR.Controllers
{
    public class TurnosController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public TurnosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
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
        public IActionResult IndexHomePublico()
        {
            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, Descripcion = "[SELECCIONE UNA PROVINCIA]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(p => p.Descripcion), "ProvinciaID", "Descripcion");

            List<Localidad> localidades = new List<Localidad>();
            localidades.Add(new Localidad { LocalidadID = 0, Descripcion = "[SELECCIONE UNA LOCALIDAD]" });
            ViewBag.LocalidadID = new SelectList(localidades.OrderBy(p => p.Descripcion), "LocalidadID", "Descripcion");


            List<Empresa> empresa = new List<Empresa>();
            empresa.Add(new Empresa { EmpresaID = 0, RazonSocial = "[SELECCIONE UNA EMPRESA]" });
            ViewBag.EmpresaID = new SelectList(empresa.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");


           
            List<Profesional> profesional = new List<Profesional>();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[SELECCIONE UN PROFESIONAL]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

            
            List<Horario> horario = new List<Horario>();
            
            ViewBag.HorarioID = new SelectList(horario.OrderBy(p => p.HorarioCompleto), "HorarioID", "HorarioCompleto");
            

            return View();


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

            var profesionalFiltro = _context.Profesional.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            ViewBag.ProfesionalIDFiltro = new SelectList(profesionalFiltro.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");


            var empresaActual = _context.Empresa.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            ViewBag.EmpresaActual = new SelectList(empresaActual.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");

            return View();

        }

        public IActionResult ListadoTurnos()
        {
            //PRIMERO BUSCAMOS EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-ROL QUE REGISTRO TIENE
            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DEL ROL PARA BUSCAR EN LA TABLA ROL, EL NOMBRE
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r => r.Name).FirstOrDefault();
            
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var profesional = _context.Profesional.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            profesional.Add(new Profesional { ProfesionalID = 0, Nombre = "[SELECCIONE UN PROFESIONAL]" });
            ViewBag.ProfesionalID = new SelectList(profesional.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

            var profesionalFiltro = _context.Profesional.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            ViewBag.ProfesionalIDFiltro = new SelectList(profesionalFiltro.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");


            var empresaActual = _context.Empresa.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            ViewBag.EmpresaActual = new SelectList(empresaActual.OrderBy(p => p.RazonSocial), "EmpresaID", "RazonSocial");

            return View();

        }

        //CODIGO PARA GUARDAR EL TURNO
        public JsonResult GuardarTurno(int TurnoID, string Nombre, string Apellido, string Email, Int64 Telefono,DateTime FechaTurno, int LocalidadID, int EmpresaID, int ProfesionalID, int ProvinciaID, int HorarioID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido) && EmpresaID != 0 && LocalidadID != 0 && ProfesionalID != 0 && ProvinciaID != 0 && HorarioID != 0)
            {
                Nombre = Nombre.ToUpper();
                Apellido = Apellido.ToUpper();
                if (TurnoID == 0)
                {
                    // Antes de CREAR el registro debemos preguntar si existe una TURNO existente
                    if (_context.Turnos.Any(e => e.ProfesionalID == ProfesionalID && e.HorarioID == HorarioID && e.FechaTurno == FechaTurno))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Hacemos un linkiu para mostrar la hora y la fecha en una variable, y poder mostrarlo en el calendario del profesional
                        var horarioTurno = _context.Horario.Where(l => l.HorarioID == HorarioID).Select(h => h.HoraInicio).FirstOrDefault();
                        FechaTurno = FechaTurno.AddHours(horarioTurno.Hour);
                        FechaTurno = FechaTurno.AddMinutes(horarioTurno.Minute);


                        var turnoNuevo = new Turno
                        {
                            Nombre = Nombre,
                            Apellido = Apellido,
                            Email = Email,
                            Telefono = Telefono,
                            HorarioID = HorarioID,
                            FechaTurno = FechaTurno,
                            ProvinciaID = ProvinciaID,
                            LocalidadID = LocalidadID,
                            EmpresaID = EmpresaID,
                            ProfesionalID = ProfesionalID,
                            Estado = 1,

                        };

                        _context.Add(turnoNuevo);
                        _context.SaveChanges();


                        EnviarEmail(Email, Nombre, Apellido, Telefono, HorarioID, FechaTurno, ProvinciaID, LocalidadID, ProfesionalID, 1);

                        //ACA VAMOS A ENVIAR EL COBRANTE DE TURNO PENDIENTE PARA EL USUARIO QUE LO SOLICITO


                    }
                    

                }
            }
            return Json(resultado);
        }

        public void EnviarEmail(string EmailDestino, string Nombre, string Apellido, Int64 Telefono, int Horario, DateTime FechaTurno, int ProvinciaID, int LocalidadID, int ProfesionalID, int Origen)
        {
            //0 VIENE DEL CANCELAR
            //1 VIENE DEL SOLICITAR
            //2 VIENE DEL CONFIRMAR

            try
            {
                string emailA = EmailDestino;

                string emailDe = "agendar.turnos@hotmail.com";

                string emailCredencial = "agendar.turnos@hotmail.com";
                string contraseñaCredencial = "Agendar123";

                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(emailA));

                msg.From = new MailAddress(emailDe, "COMPROBANTE DE TURNO", System.Text.Encoding.UTF8);

                msg.Subject = "Mensaje de " + emailDe;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                
                //ACA LE PASAMOS LOS DATOS QUE VA A CONTENER EL EMAIL



                if (Origen == 0)
                {
                    msg.Body = "<p style= font-size: 20px;>" + "Hola Sr/a <b>" + Nombre +", "+ Apellido + "</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 25px;>" + "<b>SU TURNO FUE CANCELADO</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 25px;>" + "<b>PORFAVOR INTENTE EN DIFERENTE DIA Y HORARIO, MUCHAS GRACIAS</b>" + "</b>. </p>";

                }



                if (Origen == 1)
                {
                    msg.Body = "<p style= font-size: 20px;>" + "Hola Sr/a <b>" + Nombre + ", " + Apellido + "</b>" + "</b>. </p>";
                    msg.Body += "<p style = font - size: 40px; color: red; >" + "Estado turno: <b>SU TURNO ESTA EN PROCESO DE CONFIRMACIÓN</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 25px;>" + "<b>SE LE NOTIFICARA SI EL PROFESIONAL CONFIRMA O CANCELA SU TURNO</b>" + "</b>. </p>";

                }

                if (Origen == 2)
                {
                    

                    msg.Body = "<p style= font-size: 20px;>" + "Hola Sr/a, <b>" + Nombre + ", " + Apellido + "</b>" + "</b>. </p>";
                    msg.Body += "<p class=tituloturno>" + "Estado turno: <b>SU TURNO FUE CONFIRMADO CON EXITO</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 25px;>" + "<b>DATOS DEL COMPROBANTE:</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 20px;>" + "<b>TELEFONO:</b> <b>" + Telefono + "</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 20px;>" + "<b>FECHA Y HORA:</b> <b>" + FechaTurno + "</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 20px;>" + "<b>PROVINCIA:</b> <b>" + ProvinciaID + "</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 20px;>" + "<b>LOCALIDAD:</b> <b>" + LocalidadID + "</b>" + "</b>. </p>";
                    msg.Body += "<p style= font-size: 20px;>" + "<b>PROFESIONAL:</b> <b>" + ProfesionalID + "</b>" + "</b>. </p>";
                    

                }
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;

                SmtpClient clienteSmtp = new SmtpClient();
                clienteSmtp.Host = "smtp-mail.outlook.com";
                clienteSmtp.Port = 587;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                clienteSmtp.Credentials = new System.Net.NetworkCredential(emailCredencial, contraseñaCredencial);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Send(msg);


            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo realizar el tramite!!");
            }
        }

        //Funcion para Cancelar  Confirmar  y Finalizar el Turno

        public JsonResult EstadoTurno(int estado, int TurnoID)
        {
            var turno = _context.Turnos.Find(TurnoID);
            if (turno != null)
            {
                //Una vez solicitado, el turno se guarda como a confirmar
                if (estado == 2)
                {
                    //Guardar turno como Confirmado
                    turno.Estado = 2;

                }

                else if (estado == 0)
                {
                    //Guardar turno como Cancelado
                    turno.Estado = 0;
                }
                else
                {
                    //Guardar turno como Finalizado
                    turno.Estado = 3;
                }
                _context.SaveChanges();

                if (estado != 3)
                {
                    EnviarEmail(turno.Email, turno.Nombre, turno.Apellido, turno.Telefono, turno.HorarioID, turno.FechaTurno, turno.ProvinciaID, turno.LocalidadID, turno.ProfesionalID, estado);
                }

               
            }

            return Json(turno);
        }

        private object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        //Función para para mostrar los turnos en el Calendario del Profesional
        public JsonResult MostrarTurnosInterno(int profesionalIDFiltro)
        {
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);
            var turnosCalendario = _context.Turnos.Include(r => r.Horarios).Include(r => r.Horarios.Profesionales).Where(l => l.EmpresaID == empresaUsuarioActual.EmpresaID && l.Estado != 0).ToList();

            if (profesionalIDFiltro > 0)
            {

                turnosCalendario = (from o in turnosCalendario where o.ProfesionalID == profesionalIDFiltro select o).ToList();
            }
            List<TurnoMostrar> listadoTurnosCalendario = new List<TurnoMostrar>();
            foreach(var turno in turnosCalendario)
            {
                DateTime fechaTurno = turno.FechaTurno;
                var fechaTurnoString = string.Format("{0:s}", fechaTurno);

                var turnoMostrarCalendario = new TurnoMostrar()
                {
                    TurnoID = turno.TurnoID,
                    HorarioFecha = fechaTurnoString,
                    Nombre = turno.UsuarioNombreCompleto,
                    Estado = turno.Estado,
                    ProfesionalID = turno.Horarios.Profesionales.ProfesionalID,
                    ProfesionalNombre = turno.Horarios.Profesionales.ProfesionalNombreCompleto,
                    HorarioID = turno.Horarios.HorarioID,
                    HorarioCompleto = turno.Horarios.HorarioCompleto,
                    FechaTurno = turno.FechaTurno,
                    FechaTurnostring = turno.FechaTurno.ToString("dd/MM/yyyy"),
                    Email = turno.Email,

                };
                listadoTurnosCalendario.Add(turnoMostrarCalendario);
            }
            return Json(listadoTurnosCalendario);
        }
    }
}