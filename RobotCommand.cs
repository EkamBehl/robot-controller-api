namespace robot_controller_api;

public class RobotCommand
{
    int _id;
    string _name;
    string _description;
    bool _isMoveCommand;
    DateTime _createdDate;
    DateTime _modifiedDate;
    /// Implement <see cref="RobotCommand"> here following the task sheet requirements

    public RobotCommand(int id, string name, bool isMoveCommand, DateTime createdDate, DateTime modifiedDate, string? description = null)
    {
        _id = id;
        _name = name;
        _description = description;
        _isMoveCommand = isMoveCommand;
        _createdDate = createdDate;
        _modifiedDate = modifiedDate;

    }
    public RobotCommand()
    {

    }

    public int Id {
        get{
            return _id;

        }
        set {
            _id = value;
        
        }

    }
    public DateTime CreatedDate
    {
        get
        {
            return _createdDate;

        }
        set
        {
            _createdDate = value;

        }

    }
    public DateTime ModifiedDate
    {
        get
        {
            return _modifiedDate;

        }
        set
        {
            _modifiedDate = value;

        }

    }
    public string Name
    {
        get
        {
            return _name;

        }
        set
        {
            _name = value;

        }

    }
    public bool IsMoveCommand
    {
        get
        {
            return _isMoveCommand;

        }
        set
        {
            _isMoveCommand = value;

        }

    }
    public string Description
    {
        get
        {
            return _description;

        }
        set
        {
            _description = value;

        }

    }


}
