using Demo1.Data;
using Demo1.Repo.Interfaces;

namespace Demo1.Repo.Implmentation
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
        }

        public void Delete(int id)
        {
            var s = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(s);
        }

        public List<TEntity> GetAll()
        {
           return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
          _context.Set<TEntity>().Update(entity);
        }
    }
}
