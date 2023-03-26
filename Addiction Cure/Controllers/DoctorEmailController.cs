using Addiction_Cure.core.DTO;
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
            var Renderer = new ChromePdfRenderer();
            var pdf = Renderer.RenderHtmlAsPdf($" <h1> Thank you for your purchase from our store. </h1> \n\r <h1> The Total Price for your purchase is : $  " +
                $" </h1> \n\r <h1> <p> Number of Product is : </p> Product names :   </h1> <p>Order date From </p>" +
                $"<p> Customer name is: {doctorEmail.DoctorName} </p>" +
                $"<p> Welcome To Awesome Magazine Store. </p>");
            pdf.SaveAs("DoctorEmail.pdf");

            string x = "Thank you for purchasing from our website. We hope you like our service";

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Store", "webmvc.2@gmail.com"));
            message.To.Add(MailboxAddress.Parse(doctorEmail.PatientEmail));
            message.Subject = "Invoice";
            var builder = new BodyBuilder();
            builder.TextBody = x;
            builder.HtmlBody = "<p> Thank you for purchasing from our website. We hope you like our service </p>";
            builder.Attachments.Add(@"C:\Users\User\Desktop\ABOOD\store\store\DoctorEmail.pdf");

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
