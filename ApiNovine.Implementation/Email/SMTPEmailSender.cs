using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ApiNovine.Implementation.Email
{
    public class SMTPEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("novineapiprojekat@gmail.com", "novineapi98")
            };

            var message = new MailMessage("novineapiprojekat@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);

        }
    }
}
