using CarServiceCRUDAPI.Models;

namespace CarServiceCRUDAPI.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IEnumerable<Car> GetAllClientsCarByClientId(int clientId);
    }
}
