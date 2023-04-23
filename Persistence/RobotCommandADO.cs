using Npgsql;
namespace robot_controller_api.Persistence
{



    public class RobotCommandADO : IRobotCommandDataAccess
    {

        // Connection string is usually set in a config file for the ease

        private const string CONNECTION_STRING = "Host=localhost;Username=postgres;Password=ekamb;Database=sit331";
        public List<RobotCommand> GetRobotCommands()
        {
            var robotCommands = new List<RobotCommand>();
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM robot_command", conn);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                var id = (int)dr["id"];
                string? descr = dr["description"] as string;
                string name = dr["Name"] as string;
                bool ismovecommand = (bool)dr["is_move_command"];
                DateTime createdDate = (DateTime)dr["created_date"];
                DateTime modifiedDate = (DateTime)dr["modified_date"];

                RobotCommand robotCommand = new RobotCommand(id, name, ismovecommand, createdDate, modifiedDate);

                //read values off the data reader and create a new robotCommand here and then add it to the result list.
                robotCommands.Add(robotCommand);
            }
            return robotCommands;
        }
        public RobotCommand AddRobotCommand(RobotCommand robotCommand)
        {
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO robot_command(id,name,description,is_move_command,created_date,modified_date) VALUES(DEFAULT,@name, @description,@ismovecommand,current_timestamp,current_timestamp) ", conn);
            //cmd.Parameters.AddWithValue("@id", (int)robotCommand.ID);
            cmd.Parameters.AddWithValue("@description", robotCommand.Description);
            cmd.Parameters.AddWithValue("@Name", robotCommand.Name);
            cmd.Parameters.AddWithValue("@ismovecommand", (bool)robotCommand.IsMoveCommand);
            cmd.Parameters.AddWithValue("@createddate", robotCommand.CreatedDate);
            cmd.Parameters.AddWithValue("@modifieddate", robotCommand.ModifiedDate);

            cmd.ExecuteNonQuery();
            return robotCommand;


        }
        public void DeleteRobotCommand(int id)
        {
            string command = String.Format(" DELETE FROM robot_command WHERE @id = {0}", id);
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand(command, conn);

            cmd.ExecuteNonQuery();

        }
        public RobotCommand UpdateCommand(int id, RobotCommand robotCommand)
        {
            string command = String.Format("UPDATE robot_command SET " + "Name" + "= '{0}', description = '{1}', ismovecommand = '{2}', createddate = '{3}', modifieddate = '{4}' WHERE @id = {5}", robotCommand.Name, robotCommand.Description, robotCommand.IsMoveCommand, robotCommand.CreatedDate, robotCommand.ModifiedDate, id);
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            conn.Open();
            using var cmd = new NpgsqlCommand(command, conn);

            cmd.ExecuteNonQuery();
            return robotCommand;
        }



    }
}
