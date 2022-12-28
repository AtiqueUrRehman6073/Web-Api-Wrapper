using EFDataAccess;
using EFUtilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFRepository.DataRepository
{
    public class DataRepository : IDataRepository
    {
        private IApplicationDbContext _context;
        private ApplicationDbContext context;
        public DataRepository(){}
        public DataRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<dynamic> GetEmployeesList()
        {

            Hashtable param = new Hashtable();
            context = new ApplicationDbContext();
            //param.Add("@pat_Id", "12345");
            DataTable dt = new DataTable();
            dt = await context.SELECT_DATA(SpsName.GET_PATIENT_RECORD, param);
            return JsonConvert.SerializeObject(dt,Formatting.Indented);
        }
    }
}
