using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public class FeeRepository<Fee>: DbContext<Fee>,IFeeRepository<Fee>
    {
    }
}
