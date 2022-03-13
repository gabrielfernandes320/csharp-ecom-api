namespace Domain.Common.Interfaces;

public interface IBaseRepository<T>
{
    public Task<ICollection<T>> FindAll();
    public Task<T?> FindById(Guid id);
    public Task<T> Create(T entity);
    public Task<T> Update(Guid id, T entity);
    public Task Delete(Guid id);
}