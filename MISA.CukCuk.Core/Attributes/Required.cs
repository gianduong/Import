using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Attributes
{
    /// <summary>
    /// Hàm kiểm tra sự trùng lặp cho từng Attribute
    /// </summary>
    /// CreatedBy: NGDuong (23/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplicate : Attribute
    {
        /// <summary>
        /// Thông tin về lỗi
        /// </summary>
        public String msgError = String.Empty;
        /// <summary>
        /// Kiểm tra trùng lặp cho dữ liệu
        /// </summary>
        /// <param name="msg">Thông báo</param>
        /// Createdby: NGDuong (20/05/2021)
        public Duplicate(String msg = "")
        {
            msgError = msg;
        }
    }
    /// <summary>
    /// Check dữ liệu trống
    /// </summary>
    /// Createdby: NGDuong (20/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public String msgError = String.Empty;
        public Required(String msg)
        {
            msgError = msg;
        }
    }
}
