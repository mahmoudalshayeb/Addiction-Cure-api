using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface ITestimonialsRepository
    {

        List<Testemonialac> GetAllTestimonialAC();

        Testemonialac GetTestimonialByIdAC(int id);

        void CreateTestimonialAC(Testemonialac testemonialac);
        void UpdateTestimonialAC(Testemonialac testemonialac);

        void DeleteTestimonialAC(int id);
    }
}
