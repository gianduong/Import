using Microsoft.AspNetCore.Http;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class ImportService<T> : IBaseImportService<T> where T : BaseEntity
    {
        #region Field
        IBaseService<T> _baseService;
        IBaseRepository<T> _baseRepository;
        IImportRepository<T> _ImportRepository;
        #endregion
        #region Constructor
        public ImportService(IBaseService<T> baseService, IBaseRepository<T> baseRepository, IImportRepository<T> ImportRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
            _ImportRepository = ImportRepository;
        }

        public Task<List<Customer>> ImportExcel(IFormFile formFile, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Method
        public List<T> ImportFromExcel(List<T> entities)
        {
            List<T> entitiesSucess = new List<T>();
            for (int i = 0; i < entities.Count; i++)
            {
                // Lấy dữ liệu của CustomerGroupName
                String groupName = entities[i].GetType().GetProperty("CustomerGroupName").GetValue(entities[i]).ToString();
                // kiểm tra validate 
                // 1. excel
                bool checkValidateExcel = _ImportRepository.CheckExistsInExcelFile(entities, i);
                // 2. DB
                bool checkValidateDB = _baseService.validateReturnBool(entities[i]);
                // 3. trùng GroupName
                bool checkGroupNameExists = _baseRepository.CheckGroupNameExists(entities[i], groupName);

                if (checkValidateDB == false && checkValidateExcel == false && checkGroupNameExists)
                {
                    _baseRepository.Insert(entities[i]);
                    entities[i].Status += Properties.Resources.Message_Correct;
                    entitiesSucess.Add(entities[i]);
                }
            }

            return entitiesSucess;
        }
        #endregion

    }
}
