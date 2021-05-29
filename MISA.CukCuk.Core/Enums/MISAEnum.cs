using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Enums
{
    /// <summary>
    /// Trạng thái
    /// </summary>
    /// CreatedBY: NGDuong (23/05/2021)
    public enum EntityState
    {
        /// <summary>
        /// Trạng thái Thêm
        /// </summary>
        ADD = 1,
        /// <summary>
        /// Trạng thái Sửa
        /// </summary>
        UPDATE = 2,
        /// <summary>
        /// Trạng thái Xóa
        /// </summary>
        DELETE = 3
    }
    /// <summary>
    /// Giới tính
    /// </summary>
    /// Createdby: NGDuong (20/05/2021)
    public enum Gender
    {
        /// <summary>
        /// Giới tính nam
        /// </summary>
        MALE = 1,
        /// <summary>
        /// Giới tính nữ
        /// </summary>
        FEMALE = 0,
        /// <summary>
        /// Giới tính khác
        /// </summary>
        OTHER = 2
    }


}
