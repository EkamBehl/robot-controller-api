using Microsoft.AspNetCore.Mvc;
using robot_controller_api.Persistence;

namespace robot_controller_api.Controllers;

[ApiController]
[Route("api/robot-commands")]
public class RobotCommandsController : ControllerBase


{ private readonly IRobotCommandDataAccess _robotCommandsRepo;

    public RobotCommandsController(IRobotCommandDataAccess robotCommandsRepo)
    {
        _robotCommandsRepo = robotCommandsRepo;
        
    }

   // RobotCommandADO robotCommandDataAccess = new RobotCommandADO();
    
    // Robot commands endpoints here
    [HttpGet()]
    public IEnumerable<RobotCommand> GetAllRobotCommands()
    {
        return _robotCommandsRepo.GetRobotCommands();
    }
    [HttpGet("move")]
    public IEnumerable<RobotCommand> GetMoveCommandsOnly()
    {
        return _robotCommandsRepo.GetRobotCommands().Where(i => i.IsMoveCommand == true);
    }

    [HttpGet("{id}", Name = "GetRobotCommand")]
    public IActionResult GetRobotCommandById(int id)
    {
        bool isPresent = false;

        for (int i = 0; i < _robotCommandsRepo.GetRobotCommands().Count; i++)
        {
            if (_robotCommandsRepo.GetRobotCommands()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (isPresent == true)
        {
            return Ok(_robotCommandsRepo.GetRobotCommands().Where(i => i.Id == id));
        }
        else {
            return NotFound();
        }

    }
    [HttpPost()]
    public IActionResult AddRobotCommand(RobotCommand newCommand)
    {
        
        if (newCommand == null)
        {
            return BadRequest();

        }
        for (int i = 0; i < _robotCommandsRepo.GetRobotCommands().Count; i++)
        {
            if (_robotCommandsRepo.GetRobotCommands()[i].Name == newCommand.Name)
            {
                return Conflict();

            }
            if (_robotCommandsRepo.GetRobotCommands()[i].Id == newCommand.Id)
            {
                return Conflict();

            }
        }
        newCommand.CreatedDate = DateTime.Now;
        newCommand.ModifiedDate = DateTime.Now;
        //newCommand.Id = _robotCommandsRepo.GetRobotCommands()[_robotCommandsRepo.GetRobotCommands().Count - 1].Id+1;

        _robotCommandsRepo.AddRobotCommand(newCommand);
        return CreatedAtRoute("GetRobotCommand", new { id = newCommand.Id }, newCommand);

    }
    [HttpPut("{id}")]
    public IActionResult UpdateRobotCommand(int id,RobotCommand updatedCommand)
    {
        bool isPresent = false;

        for (int i = 0; i < _robotCommandsRepo.GetRobotCommands().Count; i++)
        {
            if (_robotCommandsRepo.GetRobotCommands()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (!isPresent)
        {
            return NotFound();
        }
        _robotCommandsRepo.UpdateCommand(id, updatedCommand);
        

        return NoContent();

    }
    [HttpDelete("{id}")]
    public IActionResult DeleteRobotCommand(int id)
    {
        bool isPresent = false;

        for (int i = 0; i < _robotCommandsRepo.GetRobotCommands().Count; i++)
        {
            if (_robotCommandsRepo.GetRobotCommands()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (!isPresent)
        {
            return NotFound();
        }
        for (int i = 0; i < _robotCommandsRepo.GetRobotCommands().Count; i++)
        {
            if (_robotCommandsRepo.GetRobotCommands()[i].Id == id)
            {
                _robotCommandsRepo.DeleteRobotCommand(id);
            }
        }
        return NoContent(); 


    }

    


}
