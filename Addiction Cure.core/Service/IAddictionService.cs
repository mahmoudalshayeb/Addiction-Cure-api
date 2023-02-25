using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IAddictionService
    {

        List<Addictionsac> GetAllAddictionsAC();

        Addictionsac GetAddictionByIdAC(int id);

        void CreateAddictionAC(Addictionsac addictionsac);

        void UpdateAddictionAC(Addictionsac addictionsac);

        void DeleteAddictionAC(int id);
    }
}
