using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface kiểm tra trước khi import
    /// </summary>
    /// CreatedBy: NGDuong (28/05/2021)
    public interface IImportRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// Check khách hàng có bị trùng với số nào trong file không
        /// </summary>
        /// <param name="entities">danh sách đối tượng cần check</param>
        /// <param name="index">chỉ số trong mảng</param>
        /// <returns>
        /// true: có trùng
        /// false: không trùng
        /// </returns>
        /// CreatedBy: NGDuong (28/05/2021)   
        public bool CheckExistsInExcelFile(List<T> entities, int index);
    }
}
