using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using Addiction_Cure.core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Addiction_Cure.core.DTO;
using System.Numerics;

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
        public void register(Register patient)
        {
            var p = new DynamicParameters();
            p.Add("USERNAMEAC", patient.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PASSWORDAC", patient.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("EMAILAC", patient.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("roleidac", patient.Roleid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("firstnameAc", patient.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", patient.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", patient.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", patient.Level1, dbType: DbType.String, ParameterDirection.Input);
            p.Add("doctodIdAc", patient.Doctodid, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Register> result = dBContext.Connection.Query<Register>("LOGINAC_PACKAGE.Registers", p, commandType: CommandType.StoredProcedure);
        }







        //DoctorRegister
        public DoctorRegister DoctorRegister(DoctorRegister doctorRegister)
        {
            var p = new DynamicParameters();
            p.Add("email", doctorRegister.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("passwordac", doctorRegister.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("username", doctorRegister.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("roleidac", doctorRegister.Roleid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("firstnameAc", doctorRegister.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", doctorRegister.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", doctorRegister.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", doctorRegister.Level1, dbType: DbType.String, ParameterDirection.Input);
            p.Add("CATEGORYIDAC", doctorRegister.Categoryid, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<DoctorRegister> result = dBContext.Connection.Query<DoctorRegister>("Doctor_package.CreateDoctor", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }



    }
}
