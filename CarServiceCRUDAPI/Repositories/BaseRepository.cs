using CarServiceCRUDAPI.Models;
using Dapper;
using Npgsql;
using System.Configuration;

namespace CarServiceCRUDAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected virtual string _insertQuery { get; } = "";
        protected virtual string _deleteQuery { get; } = "";
        protected virtual string _selectOneQuery { get; } = "";
        protected virtual string _selectAllQuery { get; } = "";
        public readonly IConfiguration _configuration;
        public BaseRepository (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Create(T entity)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Execute(_insertQuery, entity) != 0;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Execute(_deleteQuery, new { id = id }) != 0;
            }
        }

        public T Get(int id)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Query<T>(_selectOneQuery, new { id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Query<T>(_selectAllQuery);
            }
        }

        public bool Update(T entity, int id)
        {
            return true;
        }
    }
}

