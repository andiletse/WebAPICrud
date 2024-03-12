using System.Collections.Generic;
using BAL.Domain;
namespace BAL.Gateways.IRepository
{
    public interface IPersonsRepository
    {
        public void Create(Person _Object);
       // public void Delete(Person _Object);
        public Person GetById(int id);
        // public IEnumerable<T> GetAll();
        // public void Save(T _Object);

    }
}
