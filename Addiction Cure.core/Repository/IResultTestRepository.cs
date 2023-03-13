using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IResultTestRepository
    {
        List<Resulttsetac> GetAllResult();
        void CreateResult(Resulttsetac resulttsetac);
        void UpdateResult(Resulttsetac resulttsetac);
        void DeleteResult(int id);
        List<Resulttsetac> GetResultBetween(DateTime datefrom, DateTime dateto);


    }
}
