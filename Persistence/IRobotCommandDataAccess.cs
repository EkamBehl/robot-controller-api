using robot_controller_api.Model;
namespace robot_controller_api.Persistence
{
    public interface IRobotCommandDataAccess
    {
        RobotCommand AddRobotCommand(RobotCommand robotCommand);
        void DeleteRobotCommand(int id);
        List<RobotCommand> GetRobotCommands();
        RobotCommand UpdateCommand(int id, RobotCommand robotCommand);
    }
}