using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IPaymentRepository
    {
        List<Paymentac> GetAllPayment();
        void CreatePayment(Paymentac paymentac);
        void UpdatePayment(Paymentac paymentac);
        void DeletePayment(int id);
    }
}
