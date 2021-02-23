using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IFeeRepository<TEntity>:IDbContext<TEntity>
    {
    }
}
