using System.Collections.Generic;
using BAL.Domain;
namespace BAL.Gateways.IRepository
{
    public interface IPersonsRepository<T>
    {
        public void Create(T _Object);
        public void Delete(T _Object);
        public T GetById(int id);
        // public IEnumerable<T> GetAll();
        // public void Save(T _Object);

    }
}
