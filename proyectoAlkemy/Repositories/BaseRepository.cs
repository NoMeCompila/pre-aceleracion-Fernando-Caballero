using Microsoft.EntityFrameworkCore;
namespace proyectoAlkemy.Repositories
{
    //contiene toda la funcionalidad generica
    //que queremos que tenga el resto de la aplicacion
    //OPERACIONES CRUD
    public abstract class BaseRepository<TEntity, TContext>//indicar entidad y contexto
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

        
        //obtiene un listado de todas las entidades
        public List<TEntity> GetAllEntities() { 
            return _dbSet.ToList();
        }

        //retorna una entidad en particular
        public TEntity GetEntity(int id) {
            return DbSet.Find(id);
        }

        //agregar una nueva entidad
        public TEntity Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges(); //cada vez que se manupulan datos de la DB es necesario gaurdar cambios
            return entity;
        }

        //borrar una entidad
        public void Delete(int id) { 
            
            var entityToDelete  = DbSet.Find(id);
            if(entityToDelete!= null)
            {
                _context.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }


        //Modificar/Actualziar una entidad
        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
