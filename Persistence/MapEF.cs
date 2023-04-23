using robot_controller_api.Context;

namespace robot_controller_api.Persistence
{
    public class MapEF : IMapDataAccess
    {
        sit331Context _context=new sit331Context();
        public void AddMap(Map map)
        {
            _context.Map.Add(map);
            _context.SaveChanges();
            
        }

        public void DeleteMap(int id)
        {
            Map map= new Map();

             map=    _context.Map.FirstOrDefault(m => m.Id == id);
            _context.Map.Remove(map);
            _context.SaveChanges();
        }

        public List<Map> GetMaps()
        {
            List<Map> list = new List<Map>();
            list = _context.Map.ToList();
            return list;

        }

        public void UpdateMap(int id, Map map)
        {
            Map map1= _context.Map.First(m => m.Id == id);
            map1.Name = map.Name;
            map1.Rows = map.Rows;
            map1.Columns = map.Columns;
            map1.Description = map.Description;
            map1.CreatedDate = map.CreatedDate;
            map1.ModifiedDate=DateTime.Now;
            _context.SaveChanges();
        }
    }
}
