using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface ITestService
    {
        List<Testac> GetAllTest();
        void CreateTest(Testac test);
        void UpdateTest(Testac test);
        void DeleteTest(int id);

        Testac GetByPatId(int id);

    }
}
