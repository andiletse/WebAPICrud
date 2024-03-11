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
        private readonly ConnSqlHelper _sqlHelper;
        private readonly IMapper _mapper;
        public RepositoryPerson(ConnSqlHelper sqlHelper, IMapper mapper, PersonDbContext context)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void Create(Person _object)
        {
            #region SQL 
            var sql = @"insert into Persons(UserName, UserEmail, UserPassword,IsDeleted,
                        CreatedOn) 
                       values(@UserName,@UserEmail,@UserPassword,@IsDeleted,@CreatedOn)";
            #endregion
            #region Execution
            // Access the connection string from the DbContext's Database property

            string ConnectionString = _sqlHelper.GetConnectionStringFromDbContext();

            // Create a new connection using the obtained connection string

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                connection.ExecuteScalar(sql,
                  param: new
                  {
                      // Id = _object.Id,
                      UserName = _object.UserName,
                      UserEmail = _object.UserEmail,
                      UserPassword = _object.UserPassword,
                      IsDeleted = _object.IsDeleted,
                      CreatedOn = _object.CreatedOn
                  });
            }
           
            #endregion

        }

        public Person GetById(int Id)
        {
            #region SQL
            var sql = @"select * from Persons where Id = @Id";
            #endregion
            #region Execution
            // Access the connection string from the DbContext's Database property
            string ConnectionString = _sqlHelper.GetConnectionStringFromDbContext();

            // Create a new connection using the obtained connection string
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var ofPersonsThatAreFoundWithIdProvided = connection.Query<Persons>(sql, new
                {
                    Id = Id
                }).FirstOrDefault();
                #endregion
                return _mapper.Map<Person>(ofPersonsThatAreFoundWithIdProvided);
            }               
        }

        public void Delete(Person _object)
        {
            #region SQL
            var sql = @"delete from Persons
                        where Id = @Id and UserName = @UserName";
            #endregion
            #region Execution
            // Access the connection string from the DbContext's Database property
            string ConnectionString = _sqlHelper.GetConnectionStringFromDbContext();

            // Create a new connection using the obtained connection string
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    Id = _object.Id,
                    Username = _object.UserName
                });
            }

            
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
