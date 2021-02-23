using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>toàn bộ dữ liệu thực thể</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="query">Lệnh truy vấn</param>
        /// <param name="cmdType">kiểu truy vấn: text, produce</param>
        /// <returns>toàn bộ dữ liệu thực thể truyền vào</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        IEnumerable<TEntity> GetAll(string query = null, CommandType cmdType = CommandType.Text);
        /// <summary>
        /// Thêm dữ liệu 
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        int Insert(TEntity entity);
        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng sửa</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        int Put(TEntity entity);
        /// <summary>
        /// Xóa đối tượng 
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        int Delete(string entityId);
    }
}
