using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEngine.EfWarehouse
{
    public interface IEmployees
    {
        public Task<dynamic> EmployeesList();
    }
}
