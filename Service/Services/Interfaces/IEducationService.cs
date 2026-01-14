using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        List<Education> GetAll();
        Education GetById(int id);
        void Create(Education education);
        void Delete(int id);
        int GetCount();
    }
}
