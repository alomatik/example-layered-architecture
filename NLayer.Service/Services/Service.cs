using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace NLayer.Service.Services
{
    public class Service<T> : IService<T> where T : class, new()
    {

        readonly IGenericRepository<T> _genericRepository;
        readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _genericRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity= await _genericRepository.GetByIdAsync(id);
            if (entity==null)
            {
                // throw new ClientSideException($"{typeof(T).Name} not found");
                throw new SqlNullValueException();
            }
            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _genericRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Where(expression);

        }
    }
}
