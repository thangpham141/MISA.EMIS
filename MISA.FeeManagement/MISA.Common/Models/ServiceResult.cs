using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Kết quả Service trả về
    /// </summary>
    /// CreatedBy: PNTHANG(20/02/2021)
    public class ServiceResult
    {
        /// <summary>
        /// Kết quả service trả về
        /// </summary>
        public ServiceResult()
        {
            Success = true;
        }
        /// <summary>
        /// Trạng thái Service (true - thành công; false - thất bại)
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// MISA Code
        /// </summary>
        public string MISACode { get; set; }


    }
}
