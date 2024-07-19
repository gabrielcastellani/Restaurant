using Restaurant.Orders.Common.Abstracts;

namespace Restaurant.Orders.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TModel>
        where TModel : ModelBase
    {
        TModel[] GetAll();
        TModel Get(Guid id);
        void Add(TModel model);
        void Update(TModel model);
        void Delete(Guid id);
    }
}
