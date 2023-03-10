using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invoicepayment : ControllerBase
    {
        [HttpPost("pay")]
        public IActionResult CreatePayment([FromBody] PaymentRequest2 paymentRequest)
        {
            StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7Tv1VlJBnKVvaKYT9c8g6j4AKZJivLI5FyXwmXKULrx9zd460qJzGo81leKa9JiJWP5VjBrq000sp9VMgWX";
           
          
            //create card
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

           
            //create cutomer
            var customeroptions = new CustomerCreateOptions
            {
                PaymentMethod = cardoptions.PaymentMethod,
                Description = "My First Test Customer",
                Email = paymentRequest.Email,
                Name = paymentRequest.Name
            };

            var customerservice = new CustomerService();
            Customer customer = customerservice.Create(customeroptions);

            var customerService = new CustomerService();
            var customers = customerService.Get(customer.Id); // Replace with the actual customer ID

            //var paymentMethodAttachOptions = new PaymentMethodAttachOptions
            //{
            //    Customer = customers.Id, // Replace with the ID of the Customer you want to attach the PaymentMethod to
            //};
            //paymentMethodService.Attach(paymentMethod.Id, paymentMethodAttachOptions);


            //var sourceptions = new CardCreateOptions
            //{
            //    Source = paymentMethod.Id,
            //};
            //var sourceservice = new CardService();
            //sourceservice.Create(customer.Id, sourceptions);

            //create product
            var Productoptions = new ProductCreateOptions
            {
                Name = paymentRequest.ProName,
            };
            var Productservice = new ProductService();
            Product product = Productservice.Create(Productoptions);

            //create plan
            var planoptions = new PlanCreateOptions
            {
                Currency=paymentRequest.Currency,
                Amount = paymentRequest.Amount,
                Interval = "month",
                Product = product.Id,
            };
            var planservice = new PlanService();
            planservice.Create(planoptions);

            //var Chargeoptions = new ChargeCreateOptions
            //{
            //    Customer = customer.Id,
            //    Amount = paymentRequest.Amount,
            //    Currency = "USD",
            //    Source = paymentMethod.Id
            //    //Description = "My First Test Charge (created for API docs at https://www.stripe.com/docs/api)",
            //};
            //var Chargeservice = new ChargeService();
            //Chargeservice.Create(Chargeoptions);


           

            return Ok(customeroptions);
        }




        //[HttpPost]
        //[Route("pay")]
        //public async Task<string> CreateInvoiceAndSendEmail([FromForm] string customerEmail, decimal amount, string description)
        //{
        //    // Set up Stripe API key
        //    //StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7EGz8Kgk3N4aATKeR0W3eOgmGXkWq1hIm0O4HgEgSoscVJcYIo7IukRXMsnHSPxoHisNffuRc00khS1hFeS";

        //    StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7PEe0f9vFQm8brueKmrQDi8YCjiz2tU5agoOvsmk3Nu6lo4TdpKFUX2WVylZxgCV84ON1i9oD00sIPAT6xG";

        //    // Create customer
        //    var options = new CustomerCreateOptions
        //    {
        //        Email = customerEmail
        //    };
        //    var service = new CustomerService();
        //    var customer = await service.CreateAsync(options);

        //    // Create invoice
        //    var invoiceOptions = new InvoiceCreateOptions
        //    {
        //        Customer = customer.Id,
        //        ApplicationFeeAmount = Convert.ToInt64(amount * 100),
        //        Currency = "usd",
        //        Description = description
        //    };
        //    var invoiceService = new InvoiceService();
        //    var invoice = await invoiceService.CreateAsync(invoiceOptions);

        //    // Send email with invoice link
        //    MimeMessage message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("abood", "abedabood009@gmail.com"));
        //    message.To.Add(MailboxAddress.Parse(customerEmail));
        //    message.Subject = "Invoice from MyCompany";
        //    var builder = new BodyBuilder();

        //    builder.TextBody = $"Please click on the following link to pay your invoice: {invoice.HostedInvoiceUrl}";
        //    message.Body = builder.ToMessageBody();

        //    using (var smtpClient = new SmtpClient())
        //    {
        //        SmtpClient client = new SmtpClient();
        //        try
        //        {
        //            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        //            client.Authenticate("webmvc.2@gmail.com", "ksthywyzlbvibhbk");
        //            client.Send(message);

        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        finally
        //        {
        //            client.Disconnect(true);
        //            client.Dispose();
        //        }
        //        await smtpClient.SendAsync(message);
        //    }

        //    return invoice.Id;
        //}

    }

    public class PaymentRequest2
    {
        public string cardNumber { get; set; }
        public string cvc { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string customerid { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public string ProName { get; set; }
        public string date { get; set; }
        public string Currency { get; set; }
    }

}
