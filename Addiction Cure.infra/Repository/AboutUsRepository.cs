﻿using Addiction_Cure.core.data;
using Addiction_Cure.core.Common;
using Addiction_Cure.core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class AboutUsRepository: IAboutUsRepository
    {
        // Inject        
        private readonly IDBContext dBContext;
        public AboutUsRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Aboutusac> GetAllAboutUs()
        {
            IEnumerable<Aboutusac> result = dBContext.Connection.Query<Aboutusac>("ABOUTUSAC_PACKAGE.GetAllABOUTUSAC", 
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void createAboutUs(Aboutusac aboutusac)
        {
            var p = new DynamicParameters();
            p.Add("IMAGES", aboutusac.Image, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH1S", aboutusac.Paragraph1, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH2S", aboutusac.Paragraph2, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH3S", aboutusac.Paragraph3, dbType: DbType.String, ParameterDirection.Input);
            
            var result = dBContext.Connection.Execute("ABOUTUSAC_PACKAGE.CreateABOUTUSAC", 
                p, commandType: CommandType.StoredProcedure);
        }
        public void updateAboutUs(Aboutusac aboutusac)
        {

            var p = new DynamicParameters();
            p.Add("AboutUsID", aboutusac.Id, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("IMAGES", aboutusac.Image, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH1S", aboutusac.Paragraph1, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH2S", aboutusac.Paragraph2, dbType: DbType.String, ParameterDirection.Input);
            p.Add("PARAGRAPH3S", aboutusac.Paragraph3, dbType: DbType.String, ParameterDirection.Input);

            var result = dBContext.Connection.Execute("ABOUTUSAC_PACKAGE.UpdateABOUTUSAC", 
                p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteAboutUs(int aboutusid)
        {
            var p = new DynamicParameters();
            p.Add("AboutUsID", aboutusid, dbType: DbType.Int32, ParameterDirection.Input);
            var result = dBContext.Connection.Execute("ABOUTUSAC_PACKAGE.DELETEABOUTUSAC", 
                p, commandType: CommandType.StoredProcedure);
            //hh
        }

    }
}
