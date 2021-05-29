using Microsoft.Extensions.Configuration;
using MISA.Common.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {        
        }
    }
}
