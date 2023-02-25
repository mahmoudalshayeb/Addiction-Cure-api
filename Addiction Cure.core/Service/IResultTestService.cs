using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IResultTestService
    {
        List<Resulttsetac> GetAllResult();
        void CreateResult(Resulttsetac resulttsetac);
        void UpdateResult(Resulttsetac resulttsetac);
        void DeleteResult(int id);
    }
}
