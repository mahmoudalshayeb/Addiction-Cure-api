using Addiction_Cure.core.data;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using Addiction_Cure.infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class TestService : ITestService
    {
        private readonly ITestRepository testRepository;
        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }



      public  List<Testac> GetAllTest()
        {
            return testRepository.GetAllTest();
        }
       public void CreateTest(Testac test)
        {
            testRepository.CreateTest(test);
        }
       public void UpdateTest(Testac test)
        {
            testRepository.UpdateTest(test);
        }
        public void DeleteTest(int id)
        {
            testRepository.DeleteTest(id);
        }
    }
}
