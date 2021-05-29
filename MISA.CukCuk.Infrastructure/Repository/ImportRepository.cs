using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class ImportRepository<T> : IImportRepository<T> where T : BaseEntity
    {
        public bool CheckExistsInExcelFile(List<T> entities, int index)
        {
   
            String CustomerCode = (entities[index]).GetType().GetProperty($"{typeof(T).Name}Code").GetValue(entities[index]).ToString();
            String PhoneNumber = (entities[index]).GetType().GetProperty("PhoneNumber").GetValue(entities[index]).ToString();

            bool checkCode = CheckcustomerCodeExistsInExcelFile(entities, index, CustomerCode);
            bool checkPhone = CheckPhoneNumberExistsInExcelFile(entities, index, PhoneNumber);

            if (checkCode || checkPhone )
                return true;
            return false;
        }
        /// <summary>
        /// Check mã khách hàng có bị trùng với số nào trong file không
        /// </summary>
        /// <param name="entities">danh sách đối tượng cần check</param>
        /// <param name="index">chỉ số trong mảng</param>
        /// <returns>
        /// true: có trùng
        /// false: không trùng
        /// </returns>
        /// CreatedBy: NGDuong (28/05/2021)   
        public bool CheckcustomerCodeExistsInExcelFile(List<T> entities, int index, String CustomerCode)
        {
            for (int i = 0; i < index; i++)
            {
                String code = (entities[i]).GetType().GetProperty($"{typeof(T).Name}Code").GetValue(entities[i]).ToString();
                if (code == CustomerCode)
                {
                    (entities[index]).Status += "Mã khách hàng đã trùng với khách hàng khác trong tệp nhập khẩu.";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check số điện thoại có bị trùng với số nào trong file không
        /// </summary>
        /// <param name="entities">danh sách đối tượng cần check</param>
        /// <param name="index">chỉ số trong mảng</param>
        /// <returns>
        /// true: có trùng
        /// false: không trùng
        /// </returns>
        /// CreatedBy: NGDuong (28/05/2021)
        public bool CheckPhoneNumberExistsInExcelFile(List<T> entities, int index, String PhoneNumber)
        {
            for (int i = 0; i < index; i++)
            {
                String phone = (entities[i]).GetType().GetProperty("PhoneNumber").GetValue(entities[i]).ToString();
                if (phone == PhoneNumber)
                {
                    (entities[index]).Status += "SĐT đã trùng với SĐT của khách hàng khác trong tệp nhập khẩu.";
                    return true;
                }
            }
            return false;
        }
    }
}
