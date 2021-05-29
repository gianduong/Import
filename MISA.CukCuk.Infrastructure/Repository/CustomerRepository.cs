using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    /// <summary>
    /// Hàm customer xử lý thao tác với bên thứ 3
    /// </summary>
    /// CreatedBy: NGDuong (19/05/2021)
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructure
        /// <summary>
        /// Hàm khởi tạo với tham số đầu vào là IConfiguration
        /// </summary>
        /// <param name="configuration">đối tượng dùng để tiêm</param>
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Method
        public bool CheckCustomerCodeExist(string customerCode)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerCodeExists";
            _parameters.Add("@d_CustomerCode", customerCode);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckEmailExists(string email)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerEmailExists";
            _parameters.Add("@d_Email", email);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }
        public bool CheckPhoneNumberExists(string phoneNumber)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"CheckCustomerPhoneNumberExists";
            _parameters.Add("@d_phoneNumber", phoneNumber);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckCustomerCodeExist(string customerCode, Guid? customerId = null)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerCodeExists";
            _parameters.Add("@d_CustomerCode", customerCode);
            _parameters.Add("@d_customerId", customerId);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckEmailExists(string email, Guid? customerId = null)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerEmailExists";
            _parameters.Add("@d_Email", email);
            _parameters.Add("@d_CustomerId", customerId);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckPhoneNumberExists(string phoneNumber, Guid? customerId = null)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerPhoneNumberExists";
            _parameters.Add("@d_PhoneNumber", phoneNumber);
            _parameters.Add("@d_CustomerId", customerId);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Customer> paging(int pageIndex, int pageSize)
        {
            var sqlCommand = $"Proc_GetCustomerPaging";
            _parameters.Add("@d_PageIndex", pageIndex);
            _parameters.Add("@d_PageSize", pageSize);

            var entities = _dbConnection.Query<Customer>(sqlCommand, param: _parameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        
        #endregion
    }
}
