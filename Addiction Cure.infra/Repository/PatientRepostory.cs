using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using LMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class PatientRepostory: IPatientRepostory
    {
        // Inject        
        private readonly IDBContext dBContext;
        public PatientRepostory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        //Get all patient
        public List<Patientac> GetAllPatient()
        {
            IEnumerable<Patientac> result = dBContext.Connection.Query<Patientac>("patientac_package.getAllPatient", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //Create Patient
        public void createpatient(Patientac patient)
        {
            var p = new DynamicParameters();
            p.Add("firstnameAc", patient.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", patient.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", patient.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", patient.Level1, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("doctodIdAc", patient.Doctodid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("loginIdac", patient.Loginid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("patientac_package.CreatePatient", p, commandType: CommandType.StoredProcedure);
        }

        //Update Patient
        public void updatepatient(Patientac patient)
        {
            var p = new DynamicParameters();
            p.Add("firstnameAc", patient.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("lastnameAc", patient.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("imagenameAc", patient.Imagename, dbType: DbType.String, ParameterDirection.Input);
            p.Add("levelAc", patient.Level1, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("doctodIdAc", patient.Doctodid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("loginIdac", patient.Loginid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("USERNAMEAC", patient.Login.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PASSWORDAC", patient.Login.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("EMAILAC", patient.Login.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("roleidac", patient.Login.Roleid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("patientac_package.Updatepatient", p, commandType: CommandType.StoredProcedure);
        }

        //delete
        public void Delete(int patientid)
        {
            var p = new DynamicParameters();
            p.Add("Id", patientid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("patientac_package.Deletepatient", p, commandType: CommandType.StoredProcedure);
        }
    }
}
