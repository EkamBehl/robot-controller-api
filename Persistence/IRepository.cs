using Npgsql;
namespace robot_controller_api.Persistence
{
    public interface IRepository
    {
        private const string CONNECTION_STRING = "Host=localhost;Username=postgres;Password=ekamb;Database=sit331";
        public List<T> ExecuteReader<T>(string sqlCommand, NpgsqlParameter[]? dbParams = null) where T : class, new()
        {
            var entities = new List<T>();
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand(sqlCommand, conn);
            if(dbParams != null)
            {
                cmd.Parameters.AddRange(dbParams.Where(x=> x.Value is not null).ToArray());
            }
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var entity = new T();
                dr.MapTo(entity);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
