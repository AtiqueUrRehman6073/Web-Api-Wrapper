using EFEngine.EFResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_Wrapper.Controllers
{

    /// <summary>
    /// EfEngine     : 2nd Layer 
    ///     => EFResources  ===>  2nd Layer Implementation
    ///     => EFWarehouse  ===>  Model-wise Repo Calling
    ///     => Helpers      ===>  Testing Modules 
    /// EfRepository : 3rd Layer
    ///     => Data Repository
    /// EfDataAccess : 4th Layer 
    ///     => Application DB Context
    /// EfEntities   : 5th Layer 
    ///     => Project DB Entities (Models)
    /// EF Utitilities
    ///     => Supplementary (Connection String + Sps Names + Other Consts)
    /// </summary>


    [Route("api/[controller]")]
    [ApiController]
    public class EF : ControllerBase
    {
        private readonly IEfResources _IResources;
        public EF(IEfResources IResources)
        {
            _IResources = IResources;
        }
        [HttpGet,Route("getAllEmployees")]
        public async Task<dynamic> EmployeesList()
        {
            return await _IResources.EmployeesList();
        }
    }
}
