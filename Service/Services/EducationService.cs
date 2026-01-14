using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repository;
        public EducationService(IEducationRepository repository)
        {
            _repository = repository;
        }
        public void Create(Education education)
        {
            _repository.Create(education);
        }

        public void Delete(int id)
        {
            Education education = _repository.GetById(id);
            if (education is null) throw new NotFoundException(ExceptionMessages.NotFound);
            _repository.Delete(education);
        }

        public List<Education> GetAll()
        {
            return _repository.GetAll();
        }
        public Education GetById(int id)
        {
            Education education = _repository.GetById(id);
            if (education is null) throw new NotFoundException(ExceptionMessages.NotFound);
            return education;
        }
        public int GetCount()
        {
            return _repository.GetCount();
        }
    }
}
