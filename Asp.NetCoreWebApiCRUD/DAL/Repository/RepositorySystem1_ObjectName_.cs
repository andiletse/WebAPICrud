using DAL.Helpers;
using DAL.Entities;
using BAL.Domain;
using BAL.Gateways.IRepository;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Authentication;


namespace DAL.Repository
{

    public class RepositorySystem1_ObjectName_ : ISystem1_ObjectName_Repository
    {
        private readonly IMapper _mapper;
        private readonly System1DbContext _context;
        
        public RepositorySystem1_ObjectName_(IMapper mapper, System1DbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        
        public void Create(System1_ObjectName _object)
        {
            var personEntity = _mapper.Map<System1_EntityName1>(_object);
            
            _context.System1_TableName1.Add(personEntity);
            _context.SaveChanges();           
        }

        public System1_ObjectName GetById(int Id)
        {
            // Execute the query using Entity Framework Core
            var ofPersonsThatAreFoundWithIdProvided = _context.System1_TableName1.FirstOrDefault(p => p.Id == Id);
            return _mapper.Map<System1_ObjectName>(ofPersonsThatAreFoundWithIdProvided);
           
        }
    }
}
