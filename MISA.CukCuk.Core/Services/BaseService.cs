using MISA.Common.Entities;
using MISA.CukCuk.Core.Attributes;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Hàm thực hiện các chức năng service cơ bản
    /// </summary>
    /// <typeparam name="T">Đối tượng cần xử lý</typeparam>
    /// CreatedBy: NGDuong (24/05/2021)
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        #region Field
        /// tiêm dữ liệu để sử dụng
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructure
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Method
        public int? Insert(T entity)
        {
            return _baseRepository.Insert(entity);
        }

        public bool validateReturnBool(T entity)
        {
            // lấy status để so sánh với kết quả sau khi check validate
            String CheckStatus = entity.Status;
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                // kiểm tra tồn tại Attribute
                var attributeDuplicate = prop.GetCustomAttributes(typeof(Duplicate), true);
                if (attributeDuplicate.Length > 0 && prop.GetValue(entity) != null)
                {
                    //lay gia tri cua propery
                    var propetyValue = prop.GetValue(entity);
                    // trường hợp thêm
                    // kiểm tra xem property có bị trùng không
                    if (_baseRepository.DuplicateData(entity, prop.Name, prop.GetValue(entity).ToString()))
                    {
                        String propNameVN;
                        //kiểm tra loại dữ liệu
                        if (prop.Name == Properties.Resources.PhoneName) propNameVN = Properties.Resources.PhoneNumber;
                        else propNameVN = Properties.Resources.CustomerCode;
                        // thông báo
                        entity.Status += string.Format(Properties.Resources.ValidateMsg_Exists, propNameVN);
                    }
                }
            }
            // kiểm tra
            if(entity.Status != CheckStatus)
                return true;
            return false;
        }

        public bool validateReturnBoolDB(T entity, List<Customer> entities)
        {
            // lấy status để so sánh với kết quả sau khi check validate
            String CheckStatus = entity.Status;
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                // kiểm tra tồn tại Attribute
                var attributeDuplicate = prop.GetCustomAttributes(typeof(Duplicate), true);
                if (attributeDuplicate.Length > 0 && prop.GetValue(entity) != null)
                {
                    //lay gia tri cua propery
                    var propetyValue = prop.GetValue(entity);
                    // trường hợp thêm
                    // kiểm tra xem property có bị trùng không
                    if (_baseRepository.DuplicateDataDB(entities, prop.Name, prop.GetValue(entity).ToString()))
                    {
                        String propNameVN;
                        //kiểm tra loại dữ liệu
                        if (prop.Name == Properties.Resources.PhoneName) propNameVN = Properties.Resources.PhoneNumber;
                        else propNameVN = Properties.Resources.CustomerCode;
                        // thông báo
                        entity.Status += string.Format(Properties.Resources.ValidateMsg_Exists, propNameVN);
                    }
                }
            }
            // kiểm tra
            if (entity.Status != CheckStatus)
                return true;
            return false;
        }

        #endregion
    }
}
