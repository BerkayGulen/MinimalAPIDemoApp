namespace DataAccess.DBAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedPrecedure, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedPrecedure, T parameters, string connectionId = "Default");
    }
}