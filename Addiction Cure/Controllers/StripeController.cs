using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stripe;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7EGz8Kgk3N4aATKeR0W3eOgmGXkWq1hIm0O4HgEgSoscVJcYIo7IukRXMsnHSPxoHisNffuRc00khS1hFeS";

            var options = new PaymentIntentCreateOptions
            {
                Amount = paymentRequest.Amount,
                Currency = paymentRequest.Currency,  
                ReceiptEmail=paymentRequest.email,
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
            };
            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);
            return Ok(paymentIntent);
        }
    }

    public class PaymentRequest
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string email { get; set;}
    }

}
