using Microsoft.EntityFrameworkCore;
namespace proyectoAlkemy.Repositories
{
    public abstract class BaseRepository<TEntity, TContext>
        where TEntity : class 
        where TContext : DbContext
    {
        private readonly TContext _context; 
        private DbSet<TEntity> _dbSet; 
        
        protected DbSet<TEntity> DbSet
        {
            get 
            {
                return _dbSet ??= _context.Set<TEntity>(); 
            }
        }

        protected BaseRepository(TContext context) 
        { 
            _context = context;
        }
        
        public List<TEntity> GetAllEntities() { 
            return _dbSet.ToList();
        }

        public TEntity GetEntity(int id) {
            return DbSet.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id) { 
            
            var entityToDelete  = DbSet.Find(id);
            if(entityToDelete!= null)
            {
                _context.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
