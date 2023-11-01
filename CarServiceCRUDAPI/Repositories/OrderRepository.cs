using CarServiceCRUDAPI.Models;
using Dapper;
using Npgsql;

namespace CarServiceCRUDAPI.Repositories
{
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    {
        protected override string _insertQuery { get; } = $@"insert into orders 
            (carid, clientid, date, description, status) 
            values
            (@{nameof(Order.CarID)},
            @{nameof(Order.ClientID)},
            @{nameof(Order.Date)},
            @{nameof(Order.Description)},
            @{nameof(Order.Status)},
            )";
        protected override string _deleteQuery { get; } = $@"delete from orders where id = @order_id";
        protected override string _selectOneQuery { get; } = $@"select 
            carid as {nameof(Order.CarID)},
            clientid as {nameof(Order.ClientID)},
            date as {nameof(Order.Date)},
            description as {nameof(Order.Description)},
            status as {nameof(Order.Status)}
            from orders where id = @order_id";
        private readonly string _selectByClientID = $@"select 
            carid as {nameof(Order.CarID)},
            clientid as {nameof(Order.ClientID)},
            date as {nameof(Order.Date)},
            description as {nameof(Order.Description)},
            status as {nameof(Order.Status)}
            from orders where clientid = @client_id";
        protected override string _selectAllQuery { get; } = $@"select 
            carid as {nameof(Order.CarID)},
            clientid as {nameof(Order.ClientID)},
            date as {nameof(Order.Date)},
            description as {nameof(Order.Description)},
            status as {nameof(Order.Status)}
            from orders";
        private readonly string _updateQuery = $@"update orders set
            carid = @carid,
            clientid = @clientid,
            date = @date,
            description = @description,
            status = @status
            where id = @order_id
            ";

        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Order> GetAllbyClientID(int clientID)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Query<Order>(_selectByClientID, new { client_id = clientID });
            }
        }
        public bool Update(Order entity, int id)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Execute(_updateQuery, new { carid = entity.CarID, clientid = entity.ClientID, date = entity.Date, description = entity.Description, status = entity.Status, car_id = id }) != 0;
            }
        }
    }
}
