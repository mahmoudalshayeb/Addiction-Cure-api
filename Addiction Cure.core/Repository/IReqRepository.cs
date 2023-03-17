using Addiction_Cure.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Repository
{
    public interface IReqRepository
    {
        Req getbydocid(int id);
        Req getbypatid(int id);

        void createReq(Req req);
        void updateReq(Req req);
    }
}
