using BLL;

namespace lab_yana_5.Actions
{

public class GetStudentsWithIdealWeightAction : ConsoleActionAbstract
{
    public GetStudentsWithIdealWeightAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers, StudentService studentService)
    {
        var studentsWithIdealWeight = studentService.ReadStudentsWithIdealWeight();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname", "Height", "Weight", "Passport series", "Passport number", "Student Id"});
        consoleHelpers.PrintLine();
        
        foreach (var student in studentsWithIdealWeight)
        {
            consoleHelpers.PrintFormattedTableRow(student);
        }
    }
}
}
