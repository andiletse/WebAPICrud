using BAL.Interfaces;
using BAL.Requests;
using BAL.Responses;
using BAL.Domain;
using BAL.Gateways.IRepository;

namespace BAL.UseCases
{
    public class CreateSystem1_ObjectName_UseCase : ICreateSytem1_ObjectName_UseCase
    {
        private readonly ISystem1_ObjectName_Repository _system1ObjectName_Repository;

        public CreateSystem1_ObjectName_UseCase(ISystem1_ObjectName_Repository system1ObjectName_Repository)
        {
            _system1ObjectName_Repository = system1ObjectName_Repository ?? throw new ArgumentNullException(nameof(system1ObjectName_Repository));   
        }

        public void Execute(CreateSytem1_ObjectName_Request request)
        {
            var system1_D1 = new System1_ObjectName
            {

                propertyName1 = request.propertyName1,
                propertyName2 = request.propertyName2,
                propertyName3 = request.propertyName3,
                propertyName4 = request.propertyName4,
                CreatedOn = DateTime.Now
            };
            _system1ObjectName_Repository.Create(system1_D1);
        }        
    }
}
