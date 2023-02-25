using Addiction_Cure.core.Common;
using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class AddictionsRepository : IAddictionsRepository
    {

        private readonly IDBContext _DbContext;



        // constructor with dependency injection from domain entity layer
        public AddictionsRepository(IDBContext DbContext)
        {
            _DbContext = DbContext;
        }






        // IMPLEMENTAION OF  GetAllAddictionsAC

        public List<Addictionsac> GetAllAddictionsAC()
        {
            IEnumerable<Addictionsac> result = _DbContext.Connection.Query<Addictionsac>("ADDICTIONS_PACKAGE.GetAllAddictionsAC",
                           commandType: CommandType.StoredProcedure);

            return result.ToList();
        }






        // IMPLEMENTAION OF  GetAddictionByIdAC

        public Addictionsac GetAddictionByIdAC(int id)
        {
            var p = new DynamicParameters();

            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Addictionsac> result = _DbContext.Connection.Query<Addictionsac>("ADDICTIONS_PACKAGE.GetAddictionByIdAC", p,
                            commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }








        // IMPLEMENTAION OF  CreateAddictionAC


        public void CreateAddictionAC(Addictionsac addictionsac)
        {
            var p = new DynamicParameters();

            p.Add("ADDICTIONNAMEAC", addictionsac.Addictionname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEAC", addictionsac.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATEGORYIDAC", addictionsac.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // you can remove the var result its ok if you dont want to know number of rows affected 
            var result = _DbContext.Connection.Execute("ADDICTIONS_PACKAGE.CreateAddictionAC", p,
                            commandType: CommandType.StoredProcedure);
        }







        // IMPLEMENTAION OF  UpdateAddictionAC


        public void UpdateAddictionAC(Addictionsac addictionsac)
        {
            var p = new DynamicParameters();
            p.Add("ID", addictionsac.Addictionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ADDICTIONNAMEAC", addictionsac.Addictionname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEAC", addictionsac.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATEGORYIDAC", addictionsac.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // you can remove the var result its ok if you dont want to know number of rows affected 
            var result = _DbContext.Connection.Execute("ADDICTIONS_PACKAGE.UpdateAddictionAC", p,
                            commandType: CommandType.StoredProcedure);
        }






        // IMPLEMENTAION OF  DeleteAddictionAC


        public void DeleteAddictionAC(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID",id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _DbContext.Connection.Execute("ADDICTIONS_PACKAGE.DeleteAddictionAC", p,
                commandType: CommandType.StoredProcedure);
        }
    }
      
       
    
}
