using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using Addiction_Cure.core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class DoctorRepository: IDoctorRepository
    {
        // Inject        
        private readonly IDBContext dBContext;
        public DoctorRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        //Get all doctor
        public List<Dictorac> GetAlldoctor()
        {
            IEnumerable<Dictorac> result = dBContext.Connection.Query<Dictorac>("Doctor_package.getAllDoctor", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //Create doctor
        public void createdoctor(Dictorac doctor)
        {
            var p = new DynamicParameters();
            p.Add("firstnameAc", doctor.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", doctor.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", doctor.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", doctor.Level1, dbType: DbType.Int32, ParameterDirection.Input);

            p.Add("doctodIdAc", doctor.Doctodid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("loginIdac", doctor.Loginid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Doctor_package.CreateDoctor", p, commandType: CommandType.StoredProcedure);
        }

        //Update doctor
        public void updatedoctor(Dictorac doctor)
        {
            var p = new DynamicParameters();
            p.Add("firstnameAc", doctor.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", doctor.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", doctor.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", doctor.Level1, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("doctodIdAc", doctor.Doctodid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("loginIdac", doctor.Loginid, dbType: DbType.Int32, ParameterDirection.Input);

            p.Add("usernameac", doctor.Login.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("passwordac", doctor.Login.Password, dbType: DbType.String, ParameterDirection.Input);

            p.Add("USERNAMEAC", doctor.Login.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PASSWORDAC", doctor.Login.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("EMAILAC", doctor.Login.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("roleidac", doctor.Login.Roleid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Doctor_package.UpdateDoctor", p, commandType: CommandType.StoredProcedure);
        }

        //delete
        public void Deletedoctor(int doctorid)
        {
            var p = new DynamicParameters();
            p.Add("Id", doctorid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Doctor_package.DeleteDoctor", p, commandType: CommandType.StoredProcedure);
        }
    }
}
