using System;
using DAL.Helpers;
using DAL.Entities;
using BAL.Domain;
using BAL.Gateways.IRepository;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace DAL.Repository
{

    public class RepositoryPerson : IPersonsRepository
    {
        private readonly IMapper _mapper;
        private readonly PersonDbContext _context;
        
        public RepositoryPerson(IMapper mapper, PersonDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public void Create(Person _object)
        {
            var personEntity=_mapper.Map<PersonEntity>(_object);
            _context.Persons.Add(personEntity);
            _context.SaveChanges();
           
        }
        
        public Person GetById(int Id)
        {
            // Execute the query using Entity Framework Core
            var ofPersonsThatAreFoundWithIdProvided = _context.Persons.FirstOrDefault(p => p.Id == Id);
            return _mapper.Map<Person>(ofPersonsThatAreFoundWithIdProvided);
           
        }
        //public void Delete(Person _object)
        //{
         
        //}
        //public IEnumerable<Person> GetAll()
        //{
        //}

        //public void Save(Person _object)
        //{
        //}
    }
}
