using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    /// <summary>
    /// Interface import data from excel
    /// </summary>
    /// <typeparam name="T">Đối tượng cần import</typeparam>
    /// CreatedBy: NgDuong (27/05/2021)
    public interface IBaseImportService<T> where T : BaseEntity
    {
        /// <summary>
        /// hàm import dữ liệu
        /// </summary>
        /// <param name="entities">đối tượng cần import</param>
        /// <returns> số lượng bảng import được</returns>
        /// CreatedBy: NgDuong (27/05/2021)
        List<T> ImportFromExcel(List<T> entities);
    }
}
