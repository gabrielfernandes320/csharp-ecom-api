using Microsoft.EntityFrameworkCore;
using Domain.Common.Entities;
using Domain.Common.Exceptions;
using Domain.Common.Interfaces;

namespace Infra.Database.Ef.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly Context _context;
    private readonly DbSet<T> _entities;

    protected BaseRepository(Context context)
    {
        _context = context;
        _entities = context.Set<T>();
    }


    public async Task<T> Create(T entity)
    {
        entity.Id = Guid.NewGuid();
        var createdEntity = await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();

        return (await FindById(createdEntity.Entity.Id))!;
    }

    public async Task Delete(Guid id)
    {
        var entity = await FindById(id);

        if(entity == null)
        {
            throw new NotFoundException();
        }

        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<T>> FindAll()
    {
        return await _entities.ToListAsync();
    }
    

    public async Task<T?> FindById(Guid id)
    {
        return await _entities.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> Update(Guid id, T entity)
    {
        var updatedEntity = _entities.Update(entity);
        await _context.SaveChangesAsync();

        return (await FindById(updatedEntity.Entity.Id))!;
    }
}