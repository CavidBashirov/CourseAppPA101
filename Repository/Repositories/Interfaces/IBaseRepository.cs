namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        List<T> GetAllWithCondition(Func<T, bool> predicate);
        T GetWithCondition(Func<T, bool> predicate);
    }
}
