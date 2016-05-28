using System.Data.Entity;
using System.Linq;

namespace Database
{
    public class Repository<Entity> : Interface<Entity> where Entity : class
    {
        protected InvoicerContext context;
        protected DbSet<Entity> dbSet;

        public Repository(InvoicerContext _context)
        {
            context = _context;
            dbSet = context.Set<Entity>();
        }

        public InvoicerContext BaseContext()
        {
            return context;
        }

        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }

        public Entity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(Entity entity, int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Entity oldEntity = Get(id);
            if (oldEntity != null)
            {
                dbSet.Remove(oldEntity);
                context.SaveChanges();
            }
        }
    }
}