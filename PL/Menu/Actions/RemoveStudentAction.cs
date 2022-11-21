using BLL;

namespace lab_yana_5.Actions
{
    public class RemoveStudentAction : ConsoleActionAbstract
{
    public RemoveStudentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers, StudentService studentService)
    {
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name: ");
        var secondName = consoleHelpers.GetStringWithMessage("Enter second name: ");
        
        studentService.Remove(firstName, secondName); 
    }
}
}
