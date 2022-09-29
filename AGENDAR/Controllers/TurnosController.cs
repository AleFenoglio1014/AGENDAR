using AGENDAR.Data;
using AGENDAR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            //LUEGO EN BASE A ESE USUARIO BUSCAMOS LA EMPRESA CON LA QUE ESTA RELACIONADA
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var profesionalFiltro = _context.Profesional.Where(p => p.Eliminado == false && p.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();
            profesionalFiltro.Add(new Profesional { ProfesionalID = 0, Nombre = "[TODOS LOS PROFESIONALES]" });
            ViewBag.ProfesionalIDFiltro = new SelectList(profesionalFiltro.OrderBy(p => p.ProfesionalNombreCompleto), "ProfesionalID", "ProfesionalNombreCompleto");

            return View();

        }

        //CODIGO PARA GUARDAR EL TURNO
        public JsonResult GuardarTurno(int TurnoID, string Nombre, string Apellido, string Email, Int64 Telefono,DateTime FechaTurno, int LocalidadID, int EmpresaID, int ProfesionalID, int ProvinciaID, int HorarioID)
        {
            int resultado = 0;
            // Si es 0 es CORRECTO
            // Si es 1 el Campo Descripcion esta VACIO
            // Si es 2 el Registro YA EXISTE con la misma Descripcion

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido) && EmpresaID != 0)
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




                        //ACA VAMOS A ENVIAR EL COBRANTE DE TURNO PENDIENTE PARA EL USUARIO QUE LO SOLICITO
                        try
                        {
                            string emailA = Email;

                            string emailDe = "agendar.turnos@hotmail.com";

                            string emailCredencial = "agendar.turnos@hotmail.com";
                            string contraseñaCredencial = "Agendar123";

                            MailMessage msg = new MailMessage();
                            msg.To.Add(new MailAddress(emailA));

                            msg.From = new MailAddress(emailDe, "COMPROBANTE DE TURNO", System.Text.Encoding.UTF8);

                            msg.Subject = "Mensaje de " + emailDe;
                            msg.SubjectEncoding = System.Text.Encoding.UTF8;

                            msg.Body = "<p style= font-size: 12pt; >" + "Estado turno: <b>A CONFIRMAR</b>" + "Nombre: <b>" + Nombre + "</b>" + "Apellido: <b>" + Apellido + "</b> . </p>";
                            msg.Body = "<p style= font-size: 12pt;>" + "Nombre: <b>" + Nombre + "</b> . </p>";
                            //msg.Body = "<p style= font-size: 12pt;>" + "Apellido: <b>" + Apellido + "</b> . </p>";



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
                            
                        }

                    }
                    

                }

            }
            return Json(resultado);
        }
        //Cancelar y Aceptar Turno
       
        //public JsonResult EstadoTurno(int TurnoID, int estado)
        //{
        //    var turno = _context.Turnos.FirstOrDefault(m => m.TurnoID == TurnoID);
        //    //if (turno != null)
        //    //{
        //    //    if (estado == 2)
        //    //    {
        //    //        turno.Estado = 2;
                    
        //    //    }
        //    //    else if (estado == 0)
        //    //    {
        //    //        turno.Estado = 0;
        //    //    }
        //    //    _context.SaveChanges();
        //    //}

        //    return Json(turno);
        //}
        

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
            var turnosCalendario = _context.Turnos.Include(r => r.Horarios).Include(r => r.Horarios.Profesionales).Where(l => l.EmpresaID == empresaUsuarioActual.EmpresaID).ToList();

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
                };
                listadoTurnosCalendario.Add(turnoMostrarCalendario);
            }
            return Json(listadoTurnosCalendario);
        }
    }
}
