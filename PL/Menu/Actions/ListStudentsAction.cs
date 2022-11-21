using BLL;

namespace lab_yana_5.Actions 
{
    

public class ListStudentsAction : ConsoleActionAbstract
{
    public ListStudentsAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers, StudentService studentService)
    {
        var students = studentService.ReadAll();
        
        consoleHelpers.PrintFormattedTableHeader(new string[] {"Name", "Surname", "Height", "Weight", "Passport series", "Passport number", "Student Id"});
        consoleHelpers.PrintLine();
        
        foreach (var student in students)
        {
            consoleHelpers.PrintFormattedTableRow(student);
        }
    }
}
}
