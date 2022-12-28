using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess
{
    public interface IApplicationDbContext
    {
        public Task<DataTable> SELECT_DATA(string QUERY, System.Collections.Hashtable PARAM);
    }
}
