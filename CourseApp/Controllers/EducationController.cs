using Domain.Entities;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
    internal class EducationController
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public void ExecuteCreate()
        {
            Console.WriteLine("Add education name");
        Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Input can't be empty:");
                goto Name;
            }

            Console.WriteLine("Add education total hours:");
        Hours: string hoursStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(hoursStr))
            {
                Console.WriteLine("Input can't be empty:");
                goto Hours;
            }

            bool isCorrectHours = int.TryParse(hoursStr, out int hours);

            if (isCorrectHours)
            {
                _educationService.Create(new Education
                {
                    Name = name,
                    TotalHours = hours
                });
            }
            else
            {
                Console.WriteLine("Input format is wrong");
                goto Hours;
            }

        }

        public void ExecuteGetAll()
        {
            var educations = _educationService.GetAll();
            foreach (var item in educations)
            {
                string education = $"{item.Id} {item.Name} {item.TotalHours} {item.CreatedDate}";
                Console.WriteLine(education);
            }
        }

        public void ExecuteDelete()
        {
            Console.WriteLine("Add education id:");
        Id: string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Input can't be empty:");
                goto Id; ;
            }

            try
            {
                bool isCorrectId = int.TryParse(idStr, out int id);
                if (isCorrectId)
                {
                    _educationService.Delete(id);
                }
                else
                {
                    Console.WriteLine("Input format is wrong");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Id;
            }
        }
    }
}