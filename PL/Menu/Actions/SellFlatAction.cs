using BLL;

namespace kyrsova_1.Actions;

public class SellFlatAction : ConsoleActionAbstract
{
    public SellFlatAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter flat id:");
        var firstName = consoleHelpers.GetStringWithMessage("Enter first name:");

        try
        {
            var flat = flatRepository.GetFlat(id);
            flatRepository.buyFlat(id, firstName);
            Console.WriteLine($"Flat with id {id} sold to {firstName}");
        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}