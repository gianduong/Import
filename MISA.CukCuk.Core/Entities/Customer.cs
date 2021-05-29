using MISA.CukCuk.Core.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    /// <summary>
    /// Thông tin khách khách
    /// </summary>
    /// CreatedBy: DuongNG (20/05/2021)
    public class Customer : BaseEntity
    {

        #region Declare

        #endregion

        #region Constructure
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Duplicate]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// giới tính
        /// </summary>
        public Gender? Gender { get; set; } = CukCuk.Core.Enums.Gender.OTHER;
        /// <summary>
        /// Mã thẻ của khách hàng
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Duplicate]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        public String CustomerGroupName { get; set; }
        #endregion

        #region Method

        #endregion


    }
}
