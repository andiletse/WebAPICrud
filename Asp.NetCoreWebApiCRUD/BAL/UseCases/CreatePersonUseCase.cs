using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Requests;
using BAL.Responses;
using BAL.Domain;
using BAL.Gateways.IRepository;

namespace BAL.UseCases
{
    public class CreatePersonUseCase : ICreatePersonUseCase
    {
        private readonly IPersonsRepository _personsRepository;


    }
}
