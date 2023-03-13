using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IPaymentService
    {
        List<Paymentac> GetAllPayment();
        void CreatePayment(Paymentac paymentac);
        void UpdatePayment(Paymentac paymentac);
        void DeletePayment(int id);
    }
}
