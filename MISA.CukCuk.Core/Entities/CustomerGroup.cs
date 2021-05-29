using MISA.CukCuk.Core.Attributes;
using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    /// <summary>
    /// Thông tin của Nhóm khách hàng
    /// </summary>
    /// CreatedBy: DuongNG (20/05/2021)
    public class CustomerGroup : BaseEntity
    {
        #region Declare

        #endregion

        #region Constructure
        public CustomerGroup()
        {
            CustomerGroupId = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        [Required(ErrorsMsg.CheckCustomerGroupName)]
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả nếu có
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region Method

        #endregion
    }
}
