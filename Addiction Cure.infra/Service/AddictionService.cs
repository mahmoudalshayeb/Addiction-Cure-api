using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class AddictionService : IAddictionService
    {


        private readonly IAddictionsRepository _addictionsRepository;


        // constructor with dependency injection from ICategoryRepository
        public AddictionService(IAddictionsRepository addictionsRepository)
        {
            _addictionsRepository = addictionsRepository;
        }





        // IMPLEMENTAION OF  GetAllAddictionsAC

        public List<Addictionsac> GetAllAddictionsAC()
        {
           return _addictionsRepository.GetAllAddictionsAC();
        }





        // IMPLEMENTAION OF  GetAddictionByIdAC


        public Addictionsac GetAddictionByIdAC(int id)
        {
            return _addictionsRepository.GetAddictionByIdAC(id);
        }






        // IMPLEMENTAION OF  CreateAddictionAC


        public void CreateAddictionAC(Addictionsac addictionsac)
        {
           _addictionsRepository.CreateAddictionAC(addictionsac);
        }




        // IMPLEMENTAION OF  UpdateAddictionAC


        public void UpdateAddictionAC(Addictionsac addictionsac)
        {
            _addictionsRepository.UpdateAddictionAC(addictionsac);
        }


        // IMPLEMENTAION OF  DeleteAddictionAC


        public void DeleteAddictionAC(int id)
        {
            _addictionsRepository.DeleteAddictionAC(id);
        }
    }
}
