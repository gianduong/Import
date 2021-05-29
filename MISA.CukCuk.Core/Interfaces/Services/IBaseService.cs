using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    /// <summary>
    /// Interface Generic
    /// </summary>
    /// <typeparam name="T">Đối tượng sử dụng service</typeparam>
    /// CreatedBy: NGDuong (24/05/2021)
    public interface IBaseService<T> where T : BaseEntity
    {
        #region Method
        /// <summary>
        /// hàm thêm mới một đối tương
        /// </summary>
        /// <param name="entity">đối tượng cần thêm mới</param>
        /// <returns>số cột bị thay đổi trong database</returns>
        /// Createdby: NGDuong (20/05/2021)
        int? Insert(T entity);

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần validate</param>
        /// <returns>
        /// false - không validate được
        /// true - validate được
        /// </returns>
        /// Createdby: NGDuong (20/05/2021)
        public bool validateReturnBool(T entity);
        #endregion

    }
}
