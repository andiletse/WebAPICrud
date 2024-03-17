
using BAL.Domain;
using DAL.Entities;
using AutoMapper;


namespace DAL.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<System1_EntityName1, System1_ObjectName>();
           CreateMap<System1_ObjectName, System1_EntityName1>();
        }
    }
}
