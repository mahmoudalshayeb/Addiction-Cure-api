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
        //    [HttpPost("pay")]
        //    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest paymentRequest)
        //    {
        //        StripeConfiguration.ApiKey = "sk_test_51MbSgMC5iNj1HcZ7Tv1VlJBnKVvaKYT9c8g6j4AKZJivLI5FyXwmXKULrx9zd460qJzGo81leKa9JiJWP5VjBrq000sp9VMgWX";
        //        var options = new PaymentIntentCreateOptions
        //        {                
        //            Currency=paymentRequest.Currency,
        //            ReceiptEmail =paymentRequest.ReceiptEmail,
        //            Amount = paymentRequest.Amount,
        //            PaymentMethodTypes = new List<string>
        //            {
        //                "card",
        //            },
        //        };


        //        var service = new PaymentIntentService();
        //        var paymentIntent = await service.CreateAsync(options);
        //        return Ok(paymentIntent);
        //    }
    }
    

    public class PaymentRequest
    {

        public int Amount { get; set; }
        public string Currency { get; set; }
        public string ReceiptEmail { get; set;}
    }

}
