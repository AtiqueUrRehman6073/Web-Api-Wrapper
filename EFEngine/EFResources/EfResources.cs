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
        private Employees? _employees;
        
        public async Task<dynamic> EmployeesList()
        {
            _employees = new Employees();
            return await _employees.EmployeesList();
        }
    }
}
