using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;

namespace MISA.CukCuk.Infrastructure.Repository
{
    /// <summary>
    /// Class thao tác trực tiếp với database
    /// </summary>
    /// <typeparam name="T">đối tượng cần thao tác</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khởi tạo kết nối đến database
        /// </summary>
        protected String _connectionString;

        // 2. Khởi tạo kết nối:
        protected IConfiguration _configuration;
        protected DynamicParameters _parameters;
        String _tableName;
        public DbConnection _dbConnection => new MySqlConnection(_connectionString);
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        #region Constructure
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _parameters = new DynamicParameters();
            _tableName = typeof(T).Name;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy toàn bộ dữ liệu trong table
        /// </summary>
        /// <returns>
        /// Danh sách các cột lấy được trong database
        /// </returns>
        public IEnumerable<T> GetAll()
        {
            var sqlCommand = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<T>(sqlCommand, commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// thêm một hàng vào trong table
        /// </summary>
        /// <param name="entity">đối tương cần thêm</param>
        /// <returns>số hàng thao tác được trên table</returns>
        public int Insert(T entity)
        {
            MappingProcParametersValueWithObject(entity);
            var storeName = $"Proc_Insert{_tableName}";
            var rowsAffect = _dbConnection.Execute(storeName, param: _parameters, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
        /// <summary>
        /// Thực hiện gán các giá trị cho tham số đầu vào của StoredProcedure với các property của Object
        /// </summary>
        /// <param name="entity">tên của Object</param>
        /// CreatedBy: NGDuong (22/05/2021)
        public void MappingProcParametersValueWithObject(T entity)
        {
            // Lấy ra các properties của đối tượng  
            var properties = typeof(T).GetProperties();
            // duyệt từng property
            foreach (var propery in properties)
            {
                // Lấy và đặt tên cho property, đặt tên tham số đầu vào và add vào dynamic
                _parameters.Add($"@d_{propery.Name}", propery.GetValue(entity));
            }
        }

        public bool DuplicateData(T entity, String duplicateName, String duplicateValue)
        {
            // lấy tên của table
            var name = typeof(T).Name;
            // tạo SqlComand
            var sqlCommand = $"Proc_Check{name}{duplicateName}Exists2";
            // add parameter
            _parameters.Add($"@d_{duplicateName}", duplicateValue);
            // thực hiện 
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckGroupNameExists(T entity, string groupName)
        {
            // Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckGroupNameExists";
            _parameters.Add("@d_CustomerGroupName", groupName);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, _parameters, commandType: CommandType.StoredProcedure);
            if (res == false)
            {
                entity.Status += Properties.Resources.Message_group;
                return false;
            }
            //if(_customerGroupRepository.MergeGroupNameWithGroupId(groupName) != null)
            //{
            //    //entity.GetType().GetProperty("CustomerGroupId").SetValue(entity, _customerGroupRepository.MergeGroupNameWithGroupId(groupName));
            //}
            
            return true;
        }
        #endregion
    }
}
