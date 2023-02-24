using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LMS.Core.Common
{
    public interface IDBContext
    {
        DbConnection Connection { get; }
    }
}
