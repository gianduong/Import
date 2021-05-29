using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface xử lý riêng của Customer
    /// </summary>
    /// CreatedBy: NGDuong (20/05/2021)
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        #region Method
        /// <summary>
        /// Check trùng mã cho hàm update
        /// </summary>
        /// <param name="customerCode">Mã khách hàng cần kiểm tra</param>
        /// <param name="customerId">Id cần sử dụng để loại trừ trong trường hợp update</param>
        /// <returns>
        /// true - có trùng
        /// false - không trùng
        /// </returns>
        /// createdBy: NGDuong (23/05/2021)
        bool CheckCustomerCodeExist(string customerCode, Guid? customerId = null);
        /// <summary>
        ///kiểm tra email có tồn tại không
        /// </summary>
        /// <param name="email">email do người dùng nhập</param>
        /// <param name="customerId">Id cần sử dụng để loại trừ trong trường hợp update</param>
        /// <returns>
        /// true - có tồn tại
        /// false - không tồn tại
        /// </returns>
        /// CreatedBy: DuongNG (20/05/2021)
        bool CheckEmailExists(String email, Guid? customerId = null);
        /// <summary>
        /// Kiểm tra xem số điện thoại có tồn tại không
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại người dùng nhập</param>
        /// <param name="customerId">Id cần sử dụng để loại trừ trong trường hợp update</param>
        /// <returns>
        /// true - có tồn tại
        /// false - không tồn tại
        /// </returns>
        /// CreatedBy: NGDuong (22/05/2021)
        bool CheckPhoneNumberExists(String phoneNumber, Guid? customerId = null);

        
        #endregion

    }
}
