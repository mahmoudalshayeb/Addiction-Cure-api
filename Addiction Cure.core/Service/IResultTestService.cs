using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IResultTestService
    {
        List<ResultTestDto> GetAllResult();
        void CreateResult(Resulttsetac resulttsetac);
        void UpdateResult(Resulttsetac resulttsetac);
        void DeleteResult(int id);
        List<Report> GetResultBetween(DateTime datefrom, DateTime dateto);

      
    }
}
