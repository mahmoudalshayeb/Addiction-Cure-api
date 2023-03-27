﻿using Addiction_Cure.core.DTO;
using IronPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorEmailController : ControllerBase
    {
        [HttpPost]
        [Route("DoctorEmail")]
        public IActionResult DoctorEmail(DoctorEmail doctorEmail)
        {           
            string x = "Thank you for purchasing from our website. We hope you like our service";

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Addiction Cure", "webmvc.2@gmail.com"));
            message.To.Add(MailboxAddress.Parse(doctorEmail.PatientEmail));
            message.Subject = "Appointment confirmed";
            var builder = new BodyBuilder();
            builder.TextBody = $"Dear{doctorEmail.PatientName}," +
                $"\r\nI am writing to confirm your next follow-up appointment on {doctorEmail.DateTest}.\r\n" +
                "\r\nDuring your appointment, you will be given a short test to determine your response to treatment.\r\n" +
                $"{doctorEmail.BodyEmail}" +
                "\r\n If you have any questions or concerns prior to your appointment, please feel free to contact us.\r\n" +
                "\r\nWe look forward to seeing you soon.\r\n" +
                "\r\nBest Regards,\r\n" +
                $"{doctorEmail.DoctorName}";

            message.Body = builder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("webmvc.2@gmail.com", "qvotnxyuirbeckfz");
                client.Send(message);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

            return (Ok());
        }
    }
}