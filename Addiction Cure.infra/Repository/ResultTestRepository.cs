using Addiction_Cure.core.Common;
using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Addiction_Cure.core.DTO;

namespace Addiction_Cure.infra.Repository
{
    public class ResultTestRepository :IResultTestRepository
    {
        private readonly IDBContext dbContext;
        public ResultTestRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

      public List<Resulttsetac> GetAllResult()
        {
            IEnumerable<Resulttsetac> result = dbContext.Connection.Query<Resulttsetac>("ResultTest_pack.GetAllResultac", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
     public void CreateResult(Resulttsetac resulttsetac)
        {
            var p = new  DynamicParameters();
            p.Add("Resulttestac", resulttsetac.Resulttest,dbType:DbType.String,ParameterDirection.Input);
            p.Add("Descriptionac", resulttsetac.Description, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Perioddateac", resulttsetac.Perioddate, dbType: DbType.Date, ParameterDirection.Input);
            p.Add("Numberoftestac", resulttsetac.Numberoftest, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Datetestac", resulttsetac.Datetest, dbType: DbType.Date, ParameterDirection.Input);
            dbContext.Connection.Execute("ResultTest_pack.CreateResultac",p,commandType:CommandType.StoredProcedure);
        }
     public void UpdateResult(Resulttsetac resulttsetac)
        {

            var p = new DynamicParameters();
            p.Add("resultAcId", resulttsetac.Resulttestid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Resulttestac", resulttsetac.Resulttest, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Descriptionac", resulttsetac.Description, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Perioddateac", resulttsetac.Perioddate, dbType: DbType.Date, ParameterDirection.Input);
            p.Add("Numberoftestac", resulttsetac.Numberoftest, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Datetestac", resulttsetac.Datetest, dbType: DbType.Date, ParameterDirection.Input);
            dbContext.Connection.Execute("ResultTest_pack.UpdateResultac", p, commandType: CommandType.StoredProcedure);

        }
     public void DeleteResult(int id)
        {
            var p = new DynamicParameters();
            p.Add("resultAcId", id, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("ResultTest_pack.DeleteResultac", p, commandType: CommandType.StoredProcedure);

        }
        public List<Report> GetResultBetween(DateTime datefrom, DateTime dateto)
        {
            var p = new DynamicParameters();
            p.Add("datetestac1", datefrom, dbType: DbType.Date, ParameterDirection.Input);
            p.Add("datetestAc2", dateto, dbType: DbType.Date, ParameterDirection.Input);
            IEnumerable<Report> result = dbContext.Connection.Query<Report>("ResultTest_pack.testbydate", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
