using BLL;

namespace lab_yana_5.Actions;

public class ChangeStudentWeightAndHeight : ConsoleActionAbstract
{
    public ChangeStudentWeightAndHeight(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers, StudentService studentService)
    {
        bool exists;
        string firstName;
        string lastName;
        
        do
        {
            firstName = consoleHelpers.GetStringWithMessage("Enter student's first name:");
            lastName = consoleHelpers.GetStringWithMessage("Enter student's last name:");
            exists = studentService.Exists(firstName, lastName);

            if (!exists)
            {
                Console.WriteLine("Student with such name and surname does not exist");
            }
        } while (!exists);

        var height = consoleHelpers.GetNumberWithMessage("Enter height:");
        var weight = consoleHelpers.GetNumberWithMessage("Enter weight:");
        
        var isIdealWeight = studentService.ChangeStudentWeightAndHeight(firstName, lastName, weight, height);

        Console.WriteLine(isIdealWeight ? "Student's weight is ideal" : "Student's weight is not ideal");
    }
}