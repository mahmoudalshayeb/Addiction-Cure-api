﻿using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
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

        List<TestWithquas> GetByPatId(int id);

        void updateStatus(int id, int status);

    }
}
