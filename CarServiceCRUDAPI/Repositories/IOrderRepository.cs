using CarServiceCRUDAPI.Models;

namespace CarServiceCRUDAPI.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> GetAllbyClientID(int clientID);
    }
}
