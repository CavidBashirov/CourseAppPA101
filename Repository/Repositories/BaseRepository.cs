using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private static int _idCounter = 1;
        public void Create(T entity)
        {
            entity.Id = _idCounter++;
            AppDbContext<T>.datas.Add(entity);
        }
        public void Delete(T entity)
        {
            AppDbContext<T>.datas.Remove(entity);
        }
        public List<T> GetAll()
        {
            return AppDbContext<T>.datas;
        }
        public List<T> GetAllWithCondition(Func<T, bool> predicate)
        {
            return AppDbContext<T>.datas.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.datas.Find(m => m.Id == id);
        }

        public T GetWithCondition(Func<T, bool> predicate)
        {
            return AppDbContext<T>.datas.FirstOrDefault(predicate);
        }
    }
}
