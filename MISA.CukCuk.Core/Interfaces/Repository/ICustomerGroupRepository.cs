using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface CustomerGroupRepository
    /// </summary>
    /// CreatedBy: NGDuong (29/05/2021)
    public interface ICustomerGroupRepository
    {
        /// <summary>
        /// Gộp nhóm khách hàng với id
        /// </summary>
        /// <param name="groupName">Tên nhóm khách hàng</param>
        /// <returns>
        /// Id của nhóm khách hàng
        /// </returns>
        /// CreatedBy: NGDuong (28/05/2021)
        public Guid? MergeGroupNameWithGroupId(String groupName);
    }
}
