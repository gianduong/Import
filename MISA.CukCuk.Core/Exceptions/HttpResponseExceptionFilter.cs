using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Exceptions
{
    // if bien T neu la customer thi ... 
    // neu la employee thi ...
    /// <summary>
    /// Hàm modify response
    /// </summary>
    /// <typeparam name="T">đối tương trả về</typeparam>
    /// CreatedBy: NGDuong (20/05/2021)
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        #region Field
        public int Order { get; } = int.MaxValue - 10;
        #endregion

        #region Method
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Kiểm tra điều kiện khác null trước để tránh exception khi không có data, stackTrace
            if (context.Exception != null)
            {
                //trong trường hợp lỗi thuộc người dùng
                if (context.Exception is GuardException exception)
                {
                    context.Result = new ObjectResult(exception.Data)
                    {
                        StatusCode = 400,
                    };
                    context.ExceptionHandled = true;
                }
                //trong trường hợp lỗi thuộc server
                else
                {
                    var responseT = new
                    {
                        // thông báo cho dev
                        devMsg = Properties.Resources.ErrorException,
                        // thông báo cho người dùng
                        userMsg = context.Exception.Message,
                        // thông báo mã lỗi nội bộ
                        errorCode = context.Exception.Source,
                        // thông tin thêm
                        moreInfo = context.Exception.Source,
                        // tra cứu thông tin log
                        traceId = context.Exception.StackTrace,
                    };

                    context.Result = new ObjectResult(responseT)
                    {
                        StatusCode = 500,
                    };
                    context.ExceptionHandled = true;
                }
            }
        }
        #endregion
    }
}
