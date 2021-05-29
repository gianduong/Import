using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerGroupRepository :BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(IConfiguration configuration, ICustomerGroupRepository customerGroupRepository):base(configuration)
        {
        }

        public Guid? MergeGroupNameWithGroupId(string groupName)
        {
            throw new NotImplementedException();
        }

        //public Guid? MergeGroupNameWithGroupId(string groupName)
        //{
        //    // Thực thi lệnh lấy dữ liệu trong Database:
        //    var sqlCommand = $"Proc_MergeCustomerGroupIdWithCustomerGroupName";
        //    _parameters.Add("@d_CustomerGroupName", groupName);
        //    Guid? res = _dbConnection.QueryFirst(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
        //    if (res != null)
        //        return res;
        //    else
        //        return Guid.Empty;
        //}
    }
}
