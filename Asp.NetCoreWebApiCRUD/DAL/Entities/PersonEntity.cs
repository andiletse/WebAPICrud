﻿
namespace DAL.Entities
{
    //mapped with person domain class
    public class PersonEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
