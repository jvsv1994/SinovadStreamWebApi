using SinovadDemo.Transversal.Collection;
using System.Linq.Expressions;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<bool> CheckIfExistAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default);
        TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        IEnumerable<TEntity> GetAllByExpression(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<DataCollection<TEntity>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy, CancellationToken cancellationToken = default);
        Task<DataCollection<TEntity>> GetAllWithPaginationByExpressionAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        TEntity Add(TEntity data);
        Task<TEntity> AddAsync(TEntity data, CancellationToken cancellationToken = default);
        void AddList(List<TEntity> list);
        Task AddListAsync(List<TEntity> list, CancellationToken cancellationToken = default);
        void Delete(int id);
        void DeleteList(List<TEntity> list);
        void DeleteByExpression(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity data);
        void Save();
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    }
}
