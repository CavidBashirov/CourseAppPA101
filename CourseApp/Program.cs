

using CourseApp.Controllers;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
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
        case 1:
            eduController.ExecuteCreate();
            break;
        case 2:
            eduController.ExecuteGetAll();
            break;
        case 3:
            Console.WriteLine("Delete method is working");
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
