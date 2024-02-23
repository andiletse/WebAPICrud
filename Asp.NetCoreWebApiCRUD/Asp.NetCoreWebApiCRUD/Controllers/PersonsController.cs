﻿using BAL;
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
    public class PersonsController : ControllerBase
    {
        private readonly Class1 class1 = new Class1();
        private readonly ICreatePersonUseCase _createPersonUseCase;

        public PersonsController(ICreatePersonUseCase createPersonUseCase)
        {
            _createPersonUseCase = createPersonUseCase ?? throw new ArgumentNullException(nameof(createPersonUseCase));
        }

        [HttpPost]
        public string Create(CreatePersonRequest Request)
        {
            _createPersonUseCase.Execute(Request);
            return class1.message;

            

        }
    }
}
