using System.Collections.Generic;
using BAL.Domain;
namespace BAL.Gateways.IRepository
{
    public interface ISystem1_ObjectName_Repository
    {
        public void Create(System1_ObjectName _Object);
       // public void Delete(Person _Object);
        public System1_ObjectName GetById(int id);
        // public IEnumerable<T> GetAll();
        // public void Save(T _Object);

    }
}
