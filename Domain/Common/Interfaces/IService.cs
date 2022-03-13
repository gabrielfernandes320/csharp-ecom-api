namespace Domain.Common.Interfaces;

public interface IService<T>
{
    public Task<T> Execute(T entity);
}

public interface IService<in T, TR>
{
    public Task<TR> Execute(T entity);
}

public interface IService<in TP, in T, TR>
{
    public Task<TR> Execute(TP param, T entity);
}