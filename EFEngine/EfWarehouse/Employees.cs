using EFRepository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEngine.EfWarehouse
{
    public class Employees: IEmployees
    {
        private readonly IDataRepository _repository;
        public Employees(IDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<dynamic> EmployeesList()
        {
            return await _repository.GetEmployeesList();
        }
    }
}
