using CourseApp.Controllers;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Enums;
using Service.Services;
using Service.Services.Interfaces;


var eduController = GetEducationController();

while (true)
{
    ShowMenues();
    Console.WriteLine("Choose one operation:");

Operation: string operationStr = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(operationStr))
    {
        Console.WriteLine("Input can't be empty");
        goto Operation;
    }

    bool operationCorrectFormat = int.TryParse(operationStr, out int operation);

    if (!operationCorrectFormat) 
    {
        Console.WriteLine("Input format is wrong");
        goto Operation;
    }


    switch (operation)
    {
        case (int)Operations.CreateEducation:
            eduController.ExecuteCreate();
            break;
        case (int)Operations.GetAllEducations:
            eduController.ExecuteGetAll();
            break;
        case (int)Operations.DeleteEducation:
            eduController.ExecuteDelete();
            break;
        case 4:
            Console.WriteLine("Delete method is working");
            break;
        default:
            Console.WriteLine("Operation notfound");
            goto Operation;
    }

}



EducationController GetEducationController()
{
    IEducationRepository educationRepository = new EducationRepository();
    IEducationService educationService = new EducationService(educationRepository);
    EducationController educationController = new(educationService);
    return educationController;
}


void ShowMenues()
{
    Console.WriteLine("Education operators: 1 - Create, 2 - GetAll, 3 - Delete");
}
