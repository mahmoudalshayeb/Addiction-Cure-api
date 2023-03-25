using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.core.Service
{
    public interface IReqService
    {
        List<Req> getbydocid(int id);
        List<Req> getbypatid(int id);
        void accept(accept accept);
        void createReq(Req req);
        void updateReq(Req req);
    }
}
