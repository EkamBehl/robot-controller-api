namespace robot_controller_api.Persistence
{
    public interface IMapDataAccess
    {
        void AddMap(Map map);
        void DeleteMap(int id);
        List<Map> GetMaps();
        void UpdateMap(int id, Map map);
    }
}