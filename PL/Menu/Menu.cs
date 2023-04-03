using BLL;
using kyrsova_1.Actions;

namespace kyrsova_1
{

public class Menu
{
    private readonly FlatRepository _flatRepository;
    private readonly VisitRepository _visitRepository;
    private readonly ConsoleHelpers _consoleHelpers;
    private static readonly ConsoleActionAbstract[] _actions =
    {
        new AddFlatForRentAction("Add flat for rent", 1),
        new AddFlatForSaleAction("Add flat for sale", 2),
        new GetAllFlatsAction("Get all flats", 3),
        new RemoveFlatAction("Remove flat", 4),
        new RentFlatAction("Rent flat", 5),
        new SellFlatAction("Sell flat", 6),
        new BookVisitAction("Book visit", 7),
        new RemoveBookedVisitAction("Remove booked visit", 8),
        new GetFlatAction("Get flat", 9),
        new GetVisitsForFlatAction("Get visits for flat", 10),
        new GetVisitAction("Get visit", 11),
        new GetAllVisitsAction("Get all visits", 12),
    };
    
    public Menu(
        FlatRepository flatRepository,
        VisitRepository visitRepository,
        ConsoleHelpers consoleHelpers
    )
    {
        _flatRepository = flatRepository;
        _visitRepository = visitRepository;
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
        action.Execute(_consoleHelpers, _flatRepository, _visitRepository);
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
