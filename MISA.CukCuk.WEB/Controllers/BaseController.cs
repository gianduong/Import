using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using MISA.CukCuk.WEB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WEB.Controllers
{
    /// <summary>
    /// Controller xử lý nghiệp vụ cơ bản
    /// </summary>
    /// <typeparam name="T">Đối tượng cần xử lý</typeparam>
    /// CreatedBy: NGDuong (24/05/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<T> : Controller, IBaseController<T> where T : BaseEntity
    {
        #region Field
        IBaseRepository<T> _baseRepository;
        IBaseService<T> _baseService;
        #endregion
        #region Constructure
        public BaseController(IBaseRepository<T> baseRepository, IBaseService<T> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion
        #region Method

        [HttpGet]
        public IActionResult Get()
        {

            var rs = _baseRepository.GetAll();
            if (rs != null)
            {
                return Ok(rs);
            }
            else
                return NoContent();

        }      

        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var rowAffects = _baseService.Insert(entity);
            return Ok(rowAffects);
        }


        #endregion

    }
}
