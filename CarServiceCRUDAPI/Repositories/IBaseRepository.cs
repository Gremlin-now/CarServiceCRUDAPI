using CarServiceCRUDAPI.Models;
using Dapper;
namespace CarServiceCRUDAPI.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        bool Create(T entity);
        T Get(int id);
        bool Update(T entity, int id);
        bool Delete(int id);
    }
}
