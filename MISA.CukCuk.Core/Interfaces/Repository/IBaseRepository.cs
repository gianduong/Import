using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Inteface thao tác với database
    /// </summary>
    /// <typeparam name="T">Dối tượng được thao tác</typeparam>
    /// Createdby: NGDuong (20/05/2021)
    public interface IBaseRepository<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// Hàm kết nối tới database
        /// </summary>
        /// Createdby: NGDuong (20/05/2021)
        DbConnection _dbConnection { get; }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// danh sách các đối tượng lấy được
        /// </returns>
        /// CreatedBy: DuongNG (20/05/2021)
        IEnumerable<T> GetAll();

        /// <summary>
        /// thêm một hàng vào trong table
        /// </summary>
        /// <param name="entity">đối tương cần thêm</param>
        /// <returns>số hàng thao tác được trên table</returns>
        /// CreatedBy: DuongNG (20/05/2021)
        int Insert(T entity);
        
        /// <summary>
        /// Xử lý duplicate cho từng thuộc tính
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="duplicateName"></param>
        /// <param name="DuplicateIdName"></param>
        /// <param name="duplicateValue"></param>
        /// <param name="Idvalue"></param>
        /// <returns></returns>
        /// Createdby: NGDuong (20/05/2021)
        public bool DuplicateData(T entity, String duplicateName, String duplicateValue);

        /// <summary>
        /// Check nhóm khách hàng có tồn tại hay không
        /// </summary>
        /// <param name="groupName">Tên nhóm khách hàng</param>
        /// <returns>
        /// true: có trùng
        /// false: không trùng
        /// </returns>
        /// CreatedBy: NGDuong (28/05/2021)
        public bool CheckGroupNameExists(T entity, String groupName);
        #endregion

    }
}
