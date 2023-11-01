using CarServiceCRUDAPI.Models;
using Dapper;
using Npgsql;
using static Dapper.SqlMapper;

namespace CarServiceCRUDAPI.Repositories
{
    public class CarRepository : BaseRepository<Car>,ICarRepository
    {
        protected override string _insertQuery { get; } = $@"insert into cars 
            (mark, model, releaseyear, vincode) 
            values
            (@{nameof(Car.Mark)},
            @{nameof(Car.Model)},
            @{nameof(Car.ReleaseYear)},
            @{nameof(Car.VINCode)})";
        protected override string _deleteQuery { get; } = $@"delete from cars where id = @car_id";
        protected override string _selectOneQuery { get; } = $@"select 
            mark as {nameof(Car.Mark)},
            model as {nameof(Car.Model)},
            releaseyear as {nameof(Car.ReleaseYear)},
            vincode as {nameof(Car.VINCode)}
            from cars where id = @id";
        protected override string _selectAllQuery { get; } = $@"select 
            mark as {nameof(Car.Mark)},
            model as {nameof(Car.Model)},
            releaseyear as {nameof(Car.ReleaseYear)},
            vincode as {nameof(Car.VINCode)}
            from cars";
        private readonly string _selectAllClientCarsByClientId = $@"select";
        private readonly string _updateQuery = $@"update cars set
            mark = @mark,
            model = @model,
            releaseyear = @releaseyear,
            vincode = @vincode
            where id = @id
            ";

        public CarRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Car> GetAllClientsCarByClientId(int clientId)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Query<Car>(_selectAllClientCarsByClientId, new { clientId = clientId});
            }
        }
    }
}
