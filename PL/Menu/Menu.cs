using BLL;
using lab_yana_5.Actions;

namespace lab_yana_5
{

public class Menu
{
    private readonly StudentService _studentService;
    private readonly ConsoleHelpers _consoleHelpers;
    private static readonly ConsoleActionAbstract[] _actions =
    {
        new GetStudentsWithIdealWeightAction("Get students with ideal weight", 1),
        new AddStudentAction("Add student", 2),
        new ListStudentsAction("List student", 3),
        new RemoveStudentAction("Remove student", 4),
        new ChangeStudentWeightAndHeight("Change student weight and height", 5),
    };
    
    public Menu(StudentService studentService, ConsoleHelpers consoleHelpers)
    {
        _studentService = studentService;
        _consoleHelpers = consoleHelpers;
    } 

    public void MainMenu()
    {
        ListActions();
    }

    private void ListActions()
    {
        Console.WriteLine("Choose action:");
        
        foreach (var action in _actions)
        {
            Console.WriteLine($"{action.Index}. {action.Name}");
        }

        WaitForAction();
    }

    private void ExecuteAction(ConsoleActionAbstract action)
    {
        action.Execute(_consoleHelpers, _studentService);
        ListActions();
        WaitForAction();
    }
    
    private void WaitForAction()
    {
        var actionIndex = GetActionIndexFromConsole();
        ExecuteAction(_actions.ElementAt(actionIndex));
    }

    private int GetActionIndexFromConsole()
    {
        var doubleRange = Enumerable.Range(1, _actions.Count()).ToArray().Select(x => (double)x).ToArray(); 
        
        var actionIndex = _consoleHelpers.GetValidNumberFromConsole(
            "Invalid action index. Please, try again.",
            doubleRange
        );

        return (int)actionIndex - 1;
    }
}
}
