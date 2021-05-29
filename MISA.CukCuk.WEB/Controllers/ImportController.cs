﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.Core.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
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

            var list = new List<Customer>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 3; row <= rowCount; row++)
                    {
                        Customer cus = new Customer();
                        if (worksheet.Cells[row, 9].Value != null)
                        {
                            cus.Email = worksheet.Cells[row, 9].Value.ToString().Trim();
                        }
                        else cus.Email = "aa";
                        if (worksheet.Cells[row, 10].Value != null)
                        {
                            cus.Address = worksheet.Cells[row, 10].Value.ToString().Trim();
                        }
                        else cus.Address = "aa";
                        if (worksheet.Cells[row, 6].Value != null)
                        {
                            // Kiểm tra date thuộc dạng nào
                            string[] arrListStr = (worksheet.Cells[row, 6].Value.ToString().Trim()).Split('/');
                            String dob = arrListStr[arrListStr.Length - 1];


                            // có đủ ngày tháng
                            if (arrListStr.Length == 3)
                            {
                                for (int i = arrListStr.Length - 2; i >= 0; i--)
                                    dob += "-" + arrListStr[i];

                            }
                            // thiếu ngày
                            else if (arrListStr.Length == 2)
                            {
                                dob += "-" + arrListStr[0] + "-01";
                            }
                            // thiếu cả ngày tháng
                            else
                            {
                                dob += "-01-01";
                            }

                            dob += "T00:00:00";
                            cus.DateOfBirth = DateTime.Parse(dob);
                        }
                        cus.CustomerCode = worksheet.Cells[row, 1].Value.ToString().Trim();
                        cus.FullName = (worksheet.Cells[row, 2].Value.ToString().Trim());
                        cus.CompanyTaxCode = (worksheet.Cells[row, 3].Value.ToString().Trim());
                        cus.PhoneNumber = worksheet.Cells[row, 5].Value.ToString().Trim();
                        cus.CompanyName = worksheet.Cells[row, 7].Value.ToString().Trim();
                        cus.MemberCardCode = worksheet.Cells[row, 8].Value.ToString().Trim();
                        cus.Note = worksheet.Cells[row, 11].Value.ToString().Trim();
                        cus.CustomerGroupName = worksheet.Cells[row, 4].Value.ToString().Trim();
                        list.Add(cus);
                    }
                }
            }
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