using System.Linq;
using robot_controller_api.Context;
using robot_controller_api.Model;
namespace robot_controller_api.Persistence
{
    public class RobotCommandEF : IRobotCommandDataAccess
    {
        sit331Context _context=new sit331Context();
        public RobotCommand AddRobotCommand(RobotCommand robotCommand)
        {
            
            _context.RobotCommand.Add(robotCommand);
            _context.SaveChanges();
            return robotCommand;
        }

        public void DeleteRobotCommand(int id)
        {
            RobotCommand robotCommand=new RobotCommand();
            robotCommand = _context.RobotCommand.FirstOrDefault(x => x.Id == id);
            _context.RobotCommand.Remove(robotCommand);

            _context.SaveChanges();
        }

        public List<RobotCommand> GetRobotCommands()
        {
            List<RobotCommand> list = new List<RobotCommand>();
            list = _context.RobotCommand.ToList();
            return list;
        }

        public RobotCommand UpdateCommand(int id, RobotCommand robotCommand)
        {
            RobotCommand robot=_context.RobotCommand.FirstOrDefault(x => x.Id == id);
            robot.Name = robotCommand.Name;
            robot.IsMoveCommand=robotCommand.IsMoveCommand;
            robot.Description= robotCommand.Description;
            robot.ModifiedDate = DateTime.Now;
            robot.CreatedDate = robotCommand.CreatedDate;

           
            _context.SaveChanges(true);
            return robotCommand;
        }
    }
}
