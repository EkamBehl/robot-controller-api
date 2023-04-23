using Microsoft.AspNetCore.Mvc;
using robot_controller_api.Persistence;
namespace robot_controller_api.Controllers;

[ApiController]
[Route("api/maps")]
public class MapsController : ControllerBase
{
    private readonly IMapDataAccess _mapRepo;

    public MapsController(IMapDataAccess mapsRepo)
    {
        _mapRepo =mapsRepo;

    }


    // Endpoints here
    [HttpGet()]
    public IEnumerable<Map> GetAllMaps()
    {

        return _mapRepo.GetMaps();
    }
    [HttpGet("square")]
    public IEnumerable<Map> GetSquareMaps()
    {
        return _mapRepo.GetMaps().Where(i => i.Rows == i.Columns);
    }
    [HttpGet("{id}", Name = "GetMap")]
    public IActionResult GetMapById(int id)
    {
        bool isPresent = false;
        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (isPresent == true)
        {
            return Ok(_mapRepo.GetMaps().Where(i => i.Id == id));
        }
        else
        {
            return NotFound();
        }
    }
    [HttpPost()]
    public IActionResult AddMap(Map newMap)
    {
        if (newMap == null)
        {
            return BadRequest();

        }
        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Name == newMap.Name)
            {
                return Conflict();

            }
            if (_mapRepo.GetMaps()[i].Id == newMap.Id)
            {
                return Conflict();

            }
        }
        newMap.CreatedDate = DateTime.Now;
        newMap.ModifiedDate = DateTime.Now;

        _mapRepo.AddMap(newMap);

       
        return CreatedAtRoute("GetRobotCommand", new { id = newMap.Id }, newMap);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateMap(int id,Map updatedMap)
    {
        bool isPresent = false;

        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (!isPresent)
        {
            return NotFound();
        }
        try
        {
            _mapRepo.UpdateMap(id, updatedMap);


        }
        catch
        {
            return BadRequest();
        }

        return NoContent();

    }
    [HttpDelete("{id}")]
    public IActionResult DeleteMap(int id)
    {
        bool isPresent = false;

        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Id == id)
            {
                isPresent = true;
            }
        }
        if (!isPresent)
        {
            return NotFound();
        }
        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Id == id)
            {
                _mapRepo.DeleteMap(id);
            }
        }
        return NoContent();
    }
    [HttpGet("{id}/{x}-{y}")]
    public IActionResult CheckCoordinate(int id, int x, int y)
    {
        int rowsOfMap = 0;
        int columnsOfMap = 0;
        if (x < 0 || y < 0)
        {
            return BadRequest();
        }
        bool isPresent = false;

        for (int i = 0; i < _mapRepo.GetMaps().Count; i++)
        {
            if (_mapRepo.GetMaps()[i].Id == id)
            {
                rowsOfMap = _mapRepo.GetMaps()[i].Rows;
                columnsOfMap = _mapRepo.GetMaps()[i].Columns;
                isPresent = true;
            }
        }
        if (!isPresent)
        {
            return NotFound();
        }
        bool isOnMap = false;
        if(x<rowsOfMap && y < columnsOfMap)
        {
            isOnMap = true;
            
        }
        return Ok(isOnMap);


    }
}
