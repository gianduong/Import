using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Các proprety của đối tượng cơ bản
    /// </summary>
    /// CreatedBy: NGDuong (24/05/2021)
    public class BaseEntity
    {
        #region Properties
        /// <summary>
        /// Ngày khởi tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người khởi tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa đổi
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Trạng thái thực hiện
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.ADD;
        /// <summary>
        /// trang thai
        /// </summary>
        public String Status { get; set; } = "";
        #endregion

    }
}
