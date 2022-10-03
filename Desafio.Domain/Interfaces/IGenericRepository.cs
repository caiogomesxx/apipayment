namespace Desafio.Domain.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        int Add(T entity);
        int Delete(int entity);
        int Update(T entity);
    }
}
