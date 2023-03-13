using Addiction_Cure.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IQuastionRepository
    {
        List<Quastionsac> GetAllQuastions();
        void CreateQuastion(Quastionsac quastionsac);
        void UpdateQuastion(Quastionsac quastionsac);
        void DeleteQuastion(int id);
    }
}
