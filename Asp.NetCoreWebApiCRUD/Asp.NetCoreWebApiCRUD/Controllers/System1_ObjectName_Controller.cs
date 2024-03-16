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
        private readonly ICreateSytem1_ObjectName_UseCase _createSystem1_ObjectName1_UseCase;

        public System1_ObjectName_Controller(ICreateSytem1_ObjectName_UseCase createSystem1_ObjectName1_UseCase)
        {
            _createSystem1_ObjectName1_UseCase = createSystem1_ObjectName1_UseCase ?? throw new ArgumentNullException(nameof(createSystem1_ObjectName1_UseCase));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSytem1_ObjectName_Request Request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _createSystem1_ObjectName1_UseCase.Execute(Request);
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error");
            }
                    
        }
    }
}
