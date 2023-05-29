namespace ParkingLot.Services
{
    public interface GeneralTypeServices<T>
    {
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Get(int id);
        T Update(T entity);
        T Delete(T entity);
    }
}
