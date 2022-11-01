using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;

namespace AGENDAR.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private string returnUrl;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El Correo Electrónico es obligatorio.")]
            [EmailAddress(ErrorMessage = "El Correo Electrónico es incorrecto.")]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()

        {
            returnUrl = returnUrl ?? Url.Content("~/Account/Login");
            if (ModelState.IsValid)
            {
                bool resultado = true;

                //borramos contraseña vieja
                var usuario = await _userManager.FindByEmailAsync(Input.Email);
                if (usuario != null)
                {
                    usuario.PasswordHash = null;

                    //armamos el objeto random
                    Random obj = new Random();

                    string posibles = "1234567890";

                    int longitud = posibles.Length;

                    char letra;

                    int longitudnuevacadena = 6;

                    string nuevacadena = "";

                    for (int i = 0; i < longitudnuevacadena; i++)
                    {
                        letra = posibles[obj.Next(longitud)];
                        nuevacadena += letra.ToString();
                    }

                    var result = await _userManager.AddPasswordAsync(usuario, nuevacadena);
                    if (result.Succeeded)
                    {
                        try
                        {
                            string emailA = Input.Email;

                            string emailDe = "agendar.turnos@hotmail.com";

                            string emailCredencial = "agendar.turnos@hotmail.com";
                            string contraseñaCredencial = "Agendar123";

                            MailMessage msg = new MailMessage();
                            msg.To.Add(new MailAddress(emailA));

                            msg.From = new MailAddress(emailDe, "Recuperación de contraseña", System.Text.Encoding.UTF8);

                            msg.Subject = "Mensaje de " + emailDe;
                            msg.SubjectEncoding = System.Text.Encoding.UTF8;

                            msg.Body = "<h2 style=color:red;>" + "Su código de recuperación es: <b>" + nuevacadena + "</b> </h2>";

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

                            return RedirectToAction("Index", "Home");
                        }
                        catch (Exception ex)
                        {
                            resultado = false;
                        }
                    }
                    resultado = false;
                }

                return RedirectToPage("./Login");
            }

            return Page();
        }
    }
}
