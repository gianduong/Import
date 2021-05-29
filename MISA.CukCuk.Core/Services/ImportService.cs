using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class ImportService<T> : IBaseImportService<T> where T : BaseEntity
    {
        #region Field
        IBaseService<T> _baseService;
        IBaseRepository<T> _baseRepository;
        ICustomerRepository _customerRepository;
        IImportRepository<T> _ImportRepository;
        #endregion
        #region Constructor
        public ImportService(IBaseService<T> baseService, IBaseRepository<T> baseRepository, ICustomerRepository customerRepository, IImportRepository<T> ImportRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
            _customerRepository = customerRepository;
            _ImportRepository = ImportRepository;
        }
        #endregion
        #region Method
        public List<T> ImportFromExcel(List<T> entities)
        {
            List<T> entitiesSucess = new List<T>();
            for (int i = 0; i < entities.Count; i++)
            {
                String groupName = entities[i].GetType().GetProperty("CustomerGroupName").GetValue(entities[i]).ToString();
                if (_ImportRepository.CheckExistsInExcelFile(entities, i) == false && _baseService.validateReturnBool(entities[i]) == false && _baseRepository.CheckGroupNameExists(entities[i], groupName))
                {
                    _baseRepository.Insert(entities[i]);
                    entities[i].Status += "Hợp lệ";
                    entitiesSucess.Add(entities[i]);
                }
            }

            return entitiesSucess;
        }
        #endregion

    }
}
