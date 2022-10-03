using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> Get(int id)
        {
            try 
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch(Exception er) 
            {
                throw er;
            }
            
        }
        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception er) 
            {
                throw er;
            }
        }
        public  int Add(T entity)
        {
            try 
            {
                _context.Add<T>(entity);
                _context.SaveChanges();
                return 0;
            }
            catch(Exception er) 
            {
                throw er;
            }

            
        }
        public int Delete(int entity)
        {
            try
            {
                var toDelete = _context.Set<T>().Find(entity);
                _context.Set<T>().Remove(toDelete);
                _context.SaveChanges();
                return 0;
            }
            catch (Exception er) 
            {
                throw er;
            }
            
        }
        public int Update(T entity)
        {
            try 
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return 0;
            }
            catch(Exception er) 
            {
                throw er;
            }
        }
    }
}
