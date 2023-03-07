using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Net.Mail;
using System.Threading.Tasks;
using System;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invoicepayment : ControllerBase
    {
        [HttpPost]
        [Route("pay")]
        public async Task<string> CreateInvoiceAndSendEmail([FromForm] string customerEmail, decimal amount, string description)
        {
            // Set up Stripe API key
            //StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7EGz8Kgk3N4aATKeR0W3eOgmGXkWq1hIm0O4HgEgSoscVJcYIo7IukRXMsnHSPxoHisNffuRc00khS1hFeS";

            StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7PEe0f9vFQm8brueKmrQDi8YCjiz2tU5agoOvsmk3Nu6lo4TdpKFUX2WVylZxgCV84ON1i9oD00sIPAT6xG";

            // Create customer
            var options = new CustomerCreateOptions
            {
                Email = customerEmail
            };
            var service = new CustomerService();
            var customer = await service.CreateAsync(options);

            // Create invoice
            var invoiceOptions = new InvoiceCreateOptions
            {
                Customer = customer.Id,
                ApplicationFeeAmount = Convert.ToInt64(amount * 100),
                Currency = "usd",
                Description = description
            };
            var invoiceService = new InvoiceService();
            var invoice = await invoiceService.CreateAsync(invoiceOptions);

            // Send email with invoice link
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("abood", "abedabood009@gmail.com"));
            message.To.Add(MailboxAddress.Parse(customerEmail));
            message.Subject = "Invoice from MyCompany";
            var builder = new BodyBuilder();

            builder.TextBody = $"Please click on the following link to pay your invoice: {invoice.HostedInvoiceUrl}";
            message.Body = builder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                SmtpClient client = new SmtpClient();
                try
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("webmvc.2@gmail.com", "ksthywyzlbvibhbk");
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
                await smtpClient.SendAsync(message);
            }

            return invoice.Id;
        }

    }
}
