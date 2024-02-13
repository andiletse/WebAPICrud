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


namespace DAL.Repository
{
   
    public class RepositoryPerson : IPersonsRepository<Person>
    {
        private readonly PersonDbContext _sqlHelper;
        private readonly IMapper _mapper;
        public RepositoryPerson(PersonDbContext sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper= mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void Create(Person _object)
        {
            #region SQL 
            var sql = @"insert into Persons(Id, UserName, UserEmail, UserPassword,IsDeleted,
                        CreatedOn) 
                       values(@Id,@UserName,@UserEmail,UserPassword,@IsDeleted,@CreatedOn)";
            #endregion
            #region Execution
            var connectionString = new SqlConnection(_sqlHelper.Connect());
            connectionString.Execute(sql, new { _object });
            #endregion

        }

        public Person GetById(int Id)
        {
            #region SQL
            var sql = @"select * from Persons where Id = @Id";
            #endregion
            #region Execution
            using var connectionString = new SqlConnection(_sqlHelper.Connect());
            var ofPersonsThatAreFoundWithIdProvided = connectionString.Query<Persons>(sql, new { Id = Id }).FirstOrDefault();
            #endregion
            return _mapper.Map<Person>(ofPersonsThatAreFoundWithIdProvided);

        }
        public void Delete(Person _object)
        {
            #region SQL
            var sql = @"delete from Persons
                        where Id = @Id and UserName = @UserName";
            #endregion
            #region Execution
            using var connection = new SqlConnection(_sqlHelper.Connect());
            connection.Execute(sql, new
            {
                Id = _object.Id,
                Username = _object.UserName
            });
            #endregion
        }
        //public IEnumerable<Person> GetAll()
        //{
        //}

        //public void Save(Person _object)
        //{
        //}
    }
}
