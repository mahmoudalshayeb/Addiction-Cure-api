using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using MimeKit;
using IronPdf;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Addiction_Cure.core.DTO;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invoicepayment : ControllerBase
    {
        [HttpPost("pay")]
        public IActionResult CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7Tv1VlJBnKVvaKYT9c8g6j4AKZJivLI5FyXwmXKULrx9zd460qJzGo81leKa9JiJWP5VjBrq000sp9VMgWX";

            // Create PaymentMethod
            var cardoptions = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = paymentRequest.cardNumber,
                    ExpMonth = paymentRequest.ExpMonth,
                    ExpYear = paymentRequest.ExpYear,
                    Cvc = paymentRequest.cvc,
                },
            };
            var paymentMethodService = new PaymentMethodService();
            PaymentMethod paymentMethod = paymentMethodService.Create(cardoptions);

            // Create Customer
            var customerOptions = new CustomerCreateOptions
            {
                Email = paymentRequest.Email,
                Name = paymentRequest.Name,
                Description = "My First Test Customer (created for API docs at https://www.stripe.com/docs/api)",
            };
            var customerService = new CustomerService();
            Customer customer = customerService.Create(customerOptions);

            // Attach PaymentMethod to Customer
            var paymentMethodAttachOptions = new PaymentMethodAttachOptions
            {
                Customer = customer.Id,
            };
            paymentMethodService.Attach(paymentMethod.Id, paymentMethodAttachOptions);

            // Create Payment
            var paymentOptions = new PaymentIntentCreateOptions
            {
                Amount = paymentRequest.Amount * 100,
                Currency = "usd",
                PaymentMethod = paymentMethod.Id,
                Customer = customer.Id,
                Confirm = true,
                OffSession = true,
            };
            var paymentService = new PaymentIntentService();
            PaymentIntent paymentIntent = paymentService.Create(paymentOptions);

            var options = new InvoiceCreateOptions
            {
                Customer = customer.Id,
            };
            var service = new InvoiceService();
            service.Create(options);

            var Renderer = new ChromePdfRenderer();
            var pdf = Renderer.RenderHtmlAsPdf($" <h1> Thank you for your purchase from our store. </h1> \n\r <h1> The Total Price for your purchase is : $  " +
                $" </h1> \n\r <h1> <p> Number of Product is : </p> Product names :   </h1> <p>Order date From </p>" +
                $"<p> Customer name is: {paymentRequest.Name} </p>" +
                $"<p> Welcome To Awesome Magazine Store. </p>");
            pdf.SaveAs("Invoice.pdf");

            string x = "Thank you for purchasing from our website. We hope you like our service";

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Store", "webmvc.2@gmail.com"));
            message.To.Add(MailboxAddress.Parse(paymentRequest.Email));
            message.Subject = "Invoice";
            var builder = new BodyBuilder();
            builder.TextBody = x;
            builder.HtmlBody = "<p> Thank you for purchasing from our website. We hope you like our service </p>";
            builder.Attachments.Add(@"C:\Users\User\Desktop\ABOOD\store\store\Invoice.pdf");

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


            return Ok(customerOptions);
        }

    }
}
