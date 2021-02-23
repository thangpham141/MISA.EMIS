using MISA.Common.Models;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DataLayer.Interfaces;

namespace MISA.Service
{
    public class FeeService:BaseService<Fee>,IFeeService
    {
        #region DECLARE
        #endregion
        #region CONTRUCTOR
        public FeeService(IFeeRepository<Fee> feeRepository) : base(feeRepository)
        {

        }
        #endregion
        #region METHOD
        #endregion
    }
}
