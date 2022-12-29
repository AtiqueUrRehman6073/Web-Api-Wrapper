using EFEngine.EfWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEngine.EFResources
{
    public class EfResources : IEfResources
    {
        private readonly IEmployees _employees;
        public EfResources(IEmployees employees)
        {
            _employees = employees;
        }        
        public async Task<dynamic> EmployeesList()
        {
            return await _employees.EmployeesList();
        }
    }
}
