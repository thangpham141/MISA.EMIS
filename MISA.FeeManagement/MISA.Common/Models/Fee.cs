using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Fee
    {
        #region CONTRUCTOR
        #endregion

        #region METHOD
        #endregion

        #region PROPERTY
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int FeeID { get; set; }
        /// <summary>
        /// Tên khoản thu
        /// </summary>
        public string FeeName { get; set; }
        /// <summary>
        /// Id nhóm khoản thu
        /// </summary>
        public int? FeeGroupID { get; set; } = null;
        /// <summary>
        /// số tiền
        /// </summary>
        public Decimal Price { get; set; }
        /// <summary>
        /// đơn vị
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Đối tượng áp dụng
        /// </summary>
        public string ApplyObject { get; set; }
        /// <summary>
        /// Kỳ thu
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// Chu kỳ thu
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// Áp dụng miễn giảm
        /// </summary>
        public Boolean IsApplyRemission { get; set; }
        /// <summary>
        /// Khoản thu bắt buộc
        /// </summary>
        public Boolean IsRequire { get; set; }
        /// <summary>
        /// Cho xuất hóa đơn
        /// </summary>
        public Boolean AllowCreateInvoice { get; set; }
        /// <summary>
        /// Cho xuất chứng từ
        /// </summary>
        public Boolean AllowCreateReceipt { get; set; }
        /// <summary>
        /// Đang hoạt động
        /// </summary>
        public Boolean IsActive { get; set; }
        /// <summary>
        /// Khoản thu bắt buộc
        /// </summary>
        public Boolean IsInternal { get; set; }
        /// <summary>
        /// Cho phép hoàn trả
        /// </summary>
        public Boolean IsSystem { get; set; }
        #endregion

        #region OTHER
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Tạo bởi
        /// </summary>
        public DateTime? CreatedBy { get; set; }
        /// <summary>
        /// Sửa bởi
        /// </summary>
        public DateTime? ModifiedBy { get; set; }
        public string TRIAL871 { get; set; }
        #endregion
    }
}
