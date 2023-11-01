using CarServiceCRUDAPI.Models;

namespace CarServiceCRUDAPI.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IBaseRepository<Client>
    {
        protected override string _insertQuery { get; } = $@"insert into orders 
            (name, surname, phonenumber, address) 
            values
            (@{nameof(Client.Name)},
            @{nameof(Client.Surname)},
            @{nameof(Client.Phone_number)},
            @{nameof(Client.Address)}
            )";
        protected override string _deleteQuery { get; } = $@"delete from orders where id = @order_id";
        protected override string _selectOneQuery { get; } = $@"select 
            name as {nameof(Client.Name)},
            surname as {nameof(Client.Surname)},
            phonenumber as {nameof(Client.Phone_number)},
            address as {nameof(Client.Address)},
            from clients where id = @order_id";
        private readonly string _selectByClientID = $@"select 
            name as {nameof(Client.Name)},
            surname as {nameof(Client.Surname)},
            phonenumber as {nameof(Client.Phone_number)},
            address as {nameof(Client.Address)},
            from orders where clientid = @client_id";
        protected override string _selectAllQuery { get; } = $@"select 
            name as {nameof(Client.Name)},
            surname as {nameof(Client.Surname)},
            phonenumber as {nameof(Client.Phone_number)},
            address as {nameof(Client.Address)},
            from orders";
        private readonly string _updateQuery = $@"update orders set
            carid = @carid,
            clientid = @clientid,
            date = @date,
            description = @description,
            status = @status
            where id = @order_id
            ";

        public ClientRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
