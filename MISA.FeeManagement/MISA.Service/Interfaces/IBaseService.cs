using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>kết quả thành công - không thành công, dữ liệu , MISA Code(hiện chưa có gì)</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        ServiceResult GetData();
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>trạng thái thêm: thành công - không thành công, dữ liệu</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        ServiceResult Post(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        ServiceResult Delete(string entityId);
        ServiceResult Put(TEntity entity, string entityCode = null);
    }
}
