using Npgsql;
namespace robot_controller_api.Persistence
{
    public class MapADO : IMapDataAccess
    {

        private const string CONNECTION_STRING = "Host=localhost;Username=postgres;Password=ekamb;Database=sit331";
        public List<Map> GetMaps()
        {
            var maps = new List<Map>();
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM map", conn);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                var id = (int)dr["id"];
                string descr = dr["description"] as string;
                string name =(string) dr["Name"];
                int rows = (int)dr["rows"];
                int columns = (int)dr["columns"];
                DateTime createdDate = (DateTime)dr["created_date"];
                DateTime modifiedDate = (DateTime)dr["modified_date"];

                Map robotCommand = new Map(id, columns, rows, name,  createdDate, modifiedDate );

                //read values off the data reader and create a new robotCommand here and then add it to the result list.
                maps.Add(robotCommand);
            }
            return maps;
        }
        public void AddMap(Map map)
        {
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO map(id,name,rows,columns,description,created_date, modified_date) VALUES(DEFAULT,@name, @rows,@columns,@description ,current_timestamp,current_timestamp) ", conn);
            //cmd.Parameters.AddWithValue("@id", (int)robotCommand.ID);
            cmd.Parameters.AddWithValue("@description", map.Description);
            cmd.Parameters.AddWithValue("@Name", map.Name);
            cmd.Parameters.AddWithValue("@rows", (int)map.Rows);
            cmd.Parameters.AddWithValue("@columns", (int)map.Columns);
            cmd.Parameters.AddWithValue("@createddate", map.CreatedDate);
            cmd.Parameters.AddWithValue("@modifieddate", map.ModifiedDate);

            cmd.ExecuteNonQuery();



        }
        public void DeleteMap(int id)
        {
            string command = String.Format(" DELETE FROM map WHERE @id = {0}", id);
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand(command, conn);

            cmd.ExecuteNonQuery();

        }
        public void UpdateMap(int id, Map map)
        {
            string command = String.Format("UPDATE map SET " + "Name" + "= '{0}', description = '{1}', rows = '{2}', columns = '{3}' ,created_date = '{4}', modified_date = '{5}' WHERE @id = {6}", map.Name, map.Description, map.Rows, map.Columns, map.CreatedDate, map.ModifiedDate, id);
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand(command, conn);

            cmd.ExecuteNonQuery();
        }

    }
}
