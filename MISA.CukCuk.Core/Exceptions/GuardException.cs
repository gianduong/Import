using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Exceptions
{
    /// <summary>
    /// Hàm Xử lý ngoại lệ, trả về status != 500
    /// </summary>
    /// <typeparam name="T">Đối tượng bị exception</typeparam>
    /// CreatedBy: NGDuong (23/05/2021)
    public class GuardException:Exception
    {

        #region Method
        /// <summary>
        /// Khởi tạo hàm ngoại lệ cho trường hợp khách hàng nhập sai
        /// </summary>
        /// <param name="msg">Nội dung thông báo</param>
        /// <param name="entity">đối tượng trả về của thông báo</param>
        /// Createdby: NNGDuong (23/05/2021)
        public GuardException(String msg = "", Object Data = null) : base(msg)
        {
            // object trả về cho client
            object objectReturn = new
            {
                //thông báo cho dev
                DevMsg = msg,
                // thông báo cho user
                userMsg = Properties.Resources.userMsg,
                // Tên object
                errorCode = Data,
                //thêm thông tin
                moreInfo = Properties.Resources.moreInfo,
                // tra cứu thông tin log
                traceId = Data
            };

            this.Data.Add("Error:", objectReturn);
        }
        #endregion


    }
}
