namespace Desafio.Domain.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        void Add(T entity);
        void Delete(int entity);
        void Update(T entity);
    }
}
