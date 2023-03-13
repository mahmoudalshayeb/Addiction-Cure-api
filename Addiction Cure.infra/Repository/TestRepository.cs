using Addiction_Cure.core.Common;
using Addiction_Cure.core.data;
using Addiction_Cure.core.Repository;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Addiction_Cure.infra.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly IDBContext dbContext;
        public TestRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

     public List<Testac> GetAllTest()
        {
            IEnumerable<Testac> result = dbContext.Connection.Query<Testac>("Testac_pack.GetAllTestac", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
      public  void CreateTest(Testac test)
        {
            var p = new DynamicParameters();
            p.Add("quationIDac", test.Quastionid, dbType: DbType.String, ParameterDirection.Input);
            p.Add("statusac", test.Status, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("paitenidac", test.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("Testac_pack.CreateTestac",p,commandType:CommandType.StoredProcedure);

        }
        public void UpdateTest(Testac test)
        {
            var p = new DynamicParameters();
            p.Add("testIdac", test.Testid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("quationIDac", test.Quastionid, dbType: DbType.String, ParameterDirection.Input);
            p.Add("statusac", test.Status, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("paitenidac", test.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("Testac_pack.UpdateTestac", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteTest(int id)
        {
            var p = new DynamicParameters();
            p.Add("testIdac",id, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("Testac_pack.DeleteTestac", p, commandType: CommandType.StoredProcedure);
        }
    }
}
