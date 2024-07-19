using Restaurant.Orders.Common.Abstracts;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;

namespace Restaurant.Orders.Infrastructure.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel>
        where TModel : ModelBase
    {
        private readonly IDictionary<Guid, TModel> _repository;

        protected Repository()
        {
            _repository = new Dictionary<Guid, TModel>();
        }

        public TModel Get(Guid id)
        {
            return _repository[id];
        }

        public TModel[] GetAll()
        {
            return _repository.Values.ToArray();
        }

        public void Add(TModel model)
        {
            if (_repository.ContainsKey(model.ID))
            {
                throw new Exception("ID is already in use for another model.");
            }

            _repository.Add(model.ID, model);
        }

        public void Update(TModel model)
        {
            if (!_repository.ContainsKey(model.ID))
            {
                throw new Exception($"Model not found! Searched ID -> {model.ID}.");
            }

            _repository[model.ID] = model;
        }

        public void Delete(Guid id)
        {
            if (!_repository.ContainsKey(id))
            {
                throw new Exception($"Model not found! Searched ID -> {id}.");
            }

            _repository.Remove(id);
        }
    }
}
