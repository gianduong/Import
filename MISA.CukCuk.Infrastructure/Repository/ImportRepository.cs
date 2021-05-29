using Microsoft.AspNetCore.Http;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class ImportRepository<T> : IImportRepository<T> where T : BaseEntity
    {
        public async Task<List<Customer>> ImportExcel(IFormFile formFile, CancellationToken cancellationToken)
        {
            var list = new List<Customer>();

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var collCount = worksheet.Dimension.Columns;

                    for (int row = 3; row <= rowCount; row++)
                    {
                        Customer cus = new Customer();
                        for (int coll = 1; coll <= collCount; coll++)
                        {
                            if (worksheet.Cells[row, coll].Value != null)
                            {
                                if (coll == 1) cus.CustomerCode = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 2) cus.FullName = (worksheet.Cells[row, coll].Value.ToString().Trim());
                                else if (coll == 3) cus.CompanyTaxCode = (worksheet.Cells[row, coll].Value.ToString().Trim());
                                else if (coll == 4) cus.CustomerGroupName = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 5) cus.PhoneNumber = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 6) cus.DateOfBirth = DateTime.ParseExact(worksheet.Cells[row, coll].Value.ToString().Trim(), new string[] { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "dd/MM/yyyy", "M/yyyy", "yyyy", "MM/yyyy" }, CultureInfo.InvariantCulture);
                                else if (coll == 7) cus.CompanyName = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 8) cus.MemberCardCode = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 9) cus.Email = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 10) cus.Address = worksheet.Cells[row, coll].Value.ToString().Trim();
                                else if (coll == 11) cus.Note = worksheet.Cells[row, coll].Value.ToString().Trim();
                            }
                        }
                        list.Add(cus);
                    }
                }
            }
            return list;
        }

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
        private bool CheckcustomerCodeExistsInExcelFile(List<T> entities, int index, String CustomerCode)
        {
            for (int i = 0; i < index; i++)
            {
                String code = (entities[i]).GetType().GetProperty($"{typeof(T).Name}Code").GetValue(entities[i]).ToString();
                if (code == CustomerCode)
                {
                    (entities[index]).Status += Properties.Resources.Message_Code_Excel;
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
        private bool CheckPhoneNumberExistsInExcelFile(List<T> entities, int index, String PhoneNumber)
        {
            for (int i = 0; i < index; i++)
            {
                String phone = (entities[i]).GetType().GetProperty("PhoneNumber").GetValue(entities[i]).ToString();
                if (phone == PhoneNumber)
                {
                    (entities[index]).Status += Properties.Resources.Message_PhoneNumber_Excel;
                    return true;
                }
            }
            return false;
        }

    }
}
