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
        [HttpPost("pay")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest paymentRequest)
        {
            StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7PEe0f9vFQm8brueKmrQDi8YCjiz2tU5agoOvsmk3Nu6lo4TdpKFUX2WVylZxgCV84ON1i9oD00sIPAT6xG";
            var options = new PaymentIntentCreateOptions
            {                
                Currency=paymentRequest.Currency,
                ReceiptEmail =paymentRequest.ReceiptEmail,
                Amount = paymentRequest.Amount,
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
        public string ReceiptEmail { get; set;}
    }

}
