
using BAL.Domain;
using DAL.Entities;
using AutoMapper;


namespace DAL.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PersonEntity, Person>();
            CreateMap<Person, PersonEntity>();
        }
    }
}
