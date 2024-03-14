using BAL;
using BAL.Interfaces;
using BAL.Requests;
using BAL.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Asp.NetCoreWebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class System1_ObjectName_Controller : ControllerBase
    {
        private readonly Class1 class1 = new Class1();
        private readonly ICreateSytem1_ObjectName_UseCase _createPersonUseCase;

        public System1_ObjectName_Controller(ICreateSytem1_ObjectName_UseCase createPersonUseCase)
        {
            _createPersonUseCase = createPersonUseCase ?? throw new ArgumentNullException(nameof(createPersonUseCase));
        }

        [HttpPost]
        public string Create(CreateSytem1_ObjectName_Request Request)
        {
            _createPersonUseCase.Execute(Request);
            return class1.message;

            

        }
    }
}
