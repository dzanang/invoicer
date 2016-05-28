using System.Linq;

namespace Database
{
    public interface Interface<Entity>
    {
        InvoicerContext BaseContext();
        IQueryable<Entity> Get();
        Entity Get(int id);
        void Insert(Entity entity);
        void Update(Entity entity, int id);
        void Delete(int id);
    }
}
