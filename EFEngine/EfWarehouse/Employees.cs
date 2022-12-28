using EFRepository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEngine.EfWarehouse
{
    public class Employees
    {
        private readonly IDataRepository _repository;
        public Employees(){}
        public Employees(IDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<dynamic> EmployeesList()
        {
            DataRepository _repo = new DataRepository();
            return await _repo.GetEmployeesList();
        }
    }
}
