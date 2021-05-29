using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    public static class ErrorsMsg
    {
        public const string NotEmptyMsg = "không được để trống";
        public const string CustomerCodeNotEmpty = "Mã khách hàng" + NotEmptyMsg;
        public const string CustomerNameNotEmpty = "Tên khách hàng" + NotEmptyMsg;
        public const string CheckCustomerGroupName = "Tên nhóm khách hàng " + NotEmptyMsg;
        public const string CheckCustomerCode = "Mã khách hàng " + NotEmptyMsg;
        public const string CheckPhoneNumber = "SĐT " + NotEmptyMsg;
        public const string NotExist = "không tồn tại.";
        public const string IsExist = "đã tồn tại trong hệ thống.";
        public const string IsExistInExcel = "đã tồn tại trong tệp nhập khẩu.";


    }
}
