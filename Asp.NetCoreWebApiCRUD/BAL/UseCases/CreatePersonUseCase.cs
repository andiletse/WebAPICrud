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
                UserName = request.person.UserName,
                UserEmail = request.person.UserEmail,
                UserPassword = request.person.UserPassword,
                CreatedOn = DateTime.Now,
                IsDeleted = request.person.IsDeleted
            };
             _personsRepository.Create(person);
        }


    }
}
