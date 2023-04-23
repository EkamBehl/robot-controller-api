namespace robot_controller_api;

public class Map
{
    int _id;
    int _columns;
    int _rows;
    string _name;
    string _description;
    DateTime _createdDate;
    DateTime _modifiedDate;
    /// Implement <see cref="Map"> here following the task sheet requirements

    public Map(int id, int columns, int rows, string name, DateTime createdDate, DateTime modifiedDate, string? description = null)
    {
        _id = id;
        _columns = columns;
        _rows = rows;
        _name = name;
        _description = description;
        _createdDate = createdDate;
        _modifiedDate = modifiedDate;

    }
    public Map()
    {

    }
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public int Columns
    {
        get { return _columns; }
        set { _columns = value; }
    }
    public int Rows
    {
        get { return _rows; }
        set
        {
            _rows = value;
        }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
}
