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

            return Ok(customerOptions);
        }
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
