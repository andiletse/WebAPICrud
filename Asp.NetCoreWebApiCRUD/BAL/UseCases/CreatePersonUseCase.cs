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

        public CreatePersonUseCase(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository ?? throw new ArgumentNullException(nameof(personsRepository));   
        }

        public void Execute(CreatePersonRequest request)
        {
            var person = new Person
            {
                
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPassword = request.UserPassword,
                CreatedOn = DateTime.Now
            };
             _personsRepository.Create(person);
        }


    }
}
