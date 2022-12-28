using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEngine.EFResources
{
    public interface IEfResources
    {
        public Task<dynamic> EmployeesList();
    }
}
