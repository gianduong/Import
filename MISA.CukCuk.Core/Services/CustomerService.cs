using MISA.Common.Entities;
using MISA.CukCuk.Core.Attributes;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Hàm thực hiện các thao tác quản lý
    /// </summary>
    /// CreatedBy: NGDuong (23/05/2021)
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Field
        ICustomerRepository _customerRepository;
        #endregion
        #region Constructure
        public CustomerService(ICustomerRepository baseRepository) : base(baseRepository)
        {
            _customerRepository = baseRepository;
        }
        #endregion
        #region Method
        #endregion
    }
}
