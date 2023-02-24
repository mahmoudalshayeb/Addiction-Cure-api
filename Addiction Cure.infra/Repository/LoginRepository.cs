using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using LMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class LoginRepository: ILoginRepository
    {
        // Inject        
        private readonly IDBContext dBContext;
        public LoginRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        //login
        public Loginac login(Loginac login)
        {
            var p = new DynamicParameters();
            p.Add("usernameac", login.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("passwordac", login.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("EMAILAC", login.Email, dbType: DbType.String, ParameterDirection.Input);
            IEnumerable<Loginac> result = dBContext.Connection.Query<Loginac>("LOGINAC_PACKAGE.LOGIN", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        //register
        public Loginac register(Loginac login)
        {
            var p = new DynamicParameters();
            p.Add("usernameac", login.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("passwordac", login.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("emailac", login.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("roleidac", login.Password, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Loginac> result = dBContext.Connection.Query<Loginac>("LOGINAC_PACKAGE.createLogincreateLogin", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
