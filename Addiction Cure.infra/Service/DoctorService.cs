using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class DoctorService: IDoctorService
    {
        //Inject
        private readonly IDoctorRepository IdoctorRepository;
        public DoctorService (IDoctorRepository IdoctorRepository)
        {
            this.IdoctorRepository = IdoctorRepository;
        }

        //get all
        public List<Dictorac> GetAlldoctor()
        {
            return IdoctorRepository.GetAlldoctor();
        }

        //create
        public void createdoctor(Dictorac doctor)
        {
            IdoctorRepository.createdoctor(doctor);
        }

        //update
        public void updatedoctor(Dictorac doctor)
        {
            IdoctorRepository.updatedoctor(doctor);
        }

        //delete
        public void Deletedoctor(int doctorid)
        {
            IdoctorRepository.Deletedoctor(doctorid);
        }
    }
}
