using Npgsql;

namespace robot_controller_api.Persistence

{
    public class RobotCommandRepository :IRobotCommandDataAccess,IRepository
    {
        private IRepository _repo => this;

        public RobotCommand AddRobotCommand(RobotCommand robotCommand)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                
                new("name",robotCommand.Name),
                new("description",robotCommand.Description?? (object)DBNull.Value),
                new("ismovecommand",robotCommand.IsMoveCommand)
            };
            var result = _repo.ExecuteReader<RobotCommand>(
               "INSERT INTO robotcommand(id,name,description,is_move_command,created_date,modified_date) VALUES(DEFAULT,@name, @description,@ismovecommand,current_timestamp,current_timestamp) RETURNING *",
               sqlParams).Single();
            return result;
        }

        public void DeleteRobotCommand(int id)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                new("id",id)
                
            };
            var result = _repo.ExecuteReader<RobotCommand>("DELETE FROM robot_command WHERE id=@id RETURNING *;  ",sqlParams).Single();
        }

        public List<RobotCommand> GetRobotCommands()
        {
            var commands = _repo.ExecuteReader<RobotCommand>("SELECT * FROM public.robot_command");
            return commands;
        }

        public RobotCommand UpdateCommand(int id, RobotCommand updatedCommand)
        {
            var sqlParams = new NpgsqlParameter[]
            {
                new("id",id),
                new("name",updatedCommand.Name),
                new("description",updatedCommand.Description?? (object)DBNull.Value),
                new("ismovecommand",updatedCommand.IsMoveCommand)
            };
            var result = _repo.ExecuteReader<RobotCommand>(
                "UPDATE robot_command SET name=@name, description=@description,is_move_command = @ismovecommand, modified_date = current_timestamp WHERE id = @id RETURNING *; ",
                sqlParams).Single();
                return result;
        }

        
    }
}
