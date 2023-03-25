using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class ResultTestService : IResultTestService
    {
        private readonly IResultTestRepository resultTestRepository;
        public ResultTestService(IResultTestRepository resultTestRepository)
        {
            this.resultTestRepository = resultTestRepository;
        }

        public List<ResultTestDto> GetAllResult()
        {
            return resultTestRepository.GetAllResult();
        }
        public void CreateResult(Resulttsetac result) {
            resultTestRepository.CreateResult(result);
        }

        public void UpdateResult(Resulttsetac result)
        {
            resultTestRepository.UpdateResult(result);
        }
        public void DeleteResult(int id)
        {
            resultTestRepository.DeleteResult(id);
        }

       public List<Report> GetResultBetween(DateTime datefrom, DateTime dateto)
        {
            return resultTestRepository.GetResultBetween(datefrom, dateto);
        }

    }
}
