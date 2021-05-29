using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.Core.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.CukCuk.WEB.Controllers
{
    /// <summary>
    /// Controller import và export dữ liệu từ excel
    /// </summary>
    /// CreatedBy: NGDuong (26/05/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        #region Field
        IBaseImportService<Customer> _baseImport;
        #endregion
        #region Constructor
        public ImportController(IBaseImportService<Customer> baseImport)
        {
            _baseImport = baseImport;
        }
        #endregion
        #region Method
        /// <summary>
        /// Hàm import dữ liệu
        /// </summary>
        /// <param name="formFile">File nguồn</param>
        /// <param name="cancellationToken">Thông báo hủy bỏ</param>
        /// <returns>
        /// - Mã code:
        /// - Thông báo thêm thành công hay thất bại
        /// - Số cột thêm được
        /// - Số cột không thêm được
        /// - danh sách các cột thêm được
        /// </returns>
        /// CreatedBy: NGDuong (26/05/2021)
        [HttpPost]
        public async Task<ResponseExcel<List<Customer>>> Import(IFormFile formFile, CancellationToken cancellationToken)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return ResponseExcel<List<Customer>>.GetResult(-1, Properties.Resources.NullFile);
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return ResponseExcel<List<Customer>>.GetResult(-1, Properties.Resources.WrongFile);
            }

            var list = await _baseImport.FomatFileFromExcel(formFile, cancellationToken);
      
            // add list to db ..  
            var successList = _baseImport.ImportFromExcel(list);
            var amount = successList.Count;
            String msg;
            if (amount > 0)
            {
                msg = Properties.Resources.InsertSuccess;
            }
            else msg = Properties.Resources.InsertFalse;
            // here just read and return  

            return ResponseExcel<List<Customer>>.GetResult(200, msg, amount, list.Count - amount, list);
        }
        #endregion

    }
}
