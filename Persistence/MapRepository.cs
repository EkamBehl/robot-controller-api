using Npgsql;
namespace robot_controller_api.Persistence
{
    public class MapRepository : IMapDataAccess, IRepository
    {
        private IRepository _repo => this;
        public void AddMap(Map map)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                new("name",map.Name),
                new("description",map.Description?? (object)DBNull.Value),
                new("rows",map.Rows),
                new("columns", map.Columns)
            };
            var result = _repo.ExecuteReader<Map>(
               "INSERT INTO map(id,name,rows,columns,description,created_date, modified_date) VALUES(DEFAULT,@name, @rows,@columns,@description ,current_timestamp,current_timestamp) RETURNING *",
               sqlParams).Single();
            
        }
    
           
       

        public void DeleteMap(int id)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                new("id",id)

            };
            var result = _repo.ExecuteReader<Map>("DELETE FROM map WHERE id=@id");
        }

        public List<Map> GetMaps()
        {

            var commands = _repo.ExecuteReader<Map>("SELECT * FROM public.map");
            return commands;
        }

        public void UpdateMap(int id, Map map)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                new("id",id),
                new("name",map.Name),
                new("description",map.Description?? (object)DBNull.Value),
                new("rows",map.Rows),
                new("columns", map.Columns)
            };
            var result = _repo.ExecuteReader<RobotCommand>(
                "UPDATE public.map SET name=@name,rows = @rows,columns=@columns,description=@description, modified_date = current_timestamp WHERE id = @id RETURNING *; ",
                sqlParams).Single();
            
        }
    }


}
