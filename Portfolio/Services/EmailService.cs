using Portfolio.Models;
using System.Net.Mail;

namespace Portfolio.Services
{
    public interface IEmailService
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task Enviar(ContactoViewModel contacto)//Para proveedor de config por si cambio el manejo de emails
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new System.Net.NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"{contacto.Nombre} ({contacto.Email}) quiere contactarte!", contacto.Mensaje);

            await smtpCliente.SendMailAsync(mensaje);
        }

    }
}
