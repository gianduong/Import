using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WEB.Interfaces
{
    /// <summary>
    /// Interface Generic
    /// </summary>
    /// <typeparam name="T">Đối tượng</typeparam>
    /// Createdby: NGDuong (24/05/2021)
    public interface IBaseController<T> where T:BaseEntity
    {
        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <return>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 500 - Lỗi ngoại lệ trên server
        /// </return>
        /// CreatedBy: DuongNG (20/05/2021)
        [HttpGet]
        public IActionResult Get();

        /// <summary>
        /// Thêm dữ liệu vào database
        /// </summary>
        /// <return>
        /// 200 - Thêm thành công
        /// 400 - Lỗi do người dùng nhập
        /// 500 - Lỗi ngoại lệ trên server
        /// </return>
        /// CreatedBy: DuongNG (20/05/2021)
        [HttpPost]
        public IActionResult Post(T entity);

        #endregion
    }
}
