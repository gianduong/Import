using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class ResponseExcel<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public int Success { get; set; }

        public int False { get; set; }

        public T ListData { get; set; }
        public static ResponseExcel<T> GetResult(int code, string msg, int amount = 0,int notAdd = 0, T data = default(T))
        {
            return new ResponseExcel<T>
            {
                Code = code,
                Msg = msg,
                Success = amount,
                False = notAdd,
                ListData = data
            };
        }
    }
}
