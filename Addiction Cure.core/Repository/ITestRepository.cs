using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface ITestRepository
    {
        List<Testac> GetAllTest();
        void CreateTest(Testac test);
        void UpdateTest(Testac test);
        void DeleteTest(int id);

    }
}
