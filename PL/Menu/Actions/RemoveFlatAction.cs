using BLL;

namespace kyrsova_1.Actions;

public class RemoveFlatAction : ConsoleActionAbstract
{
    public RemoveFlatAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter flat id:");

        try
        {
            flatRepository.RemoveFlat(id);
            Console.WriteLine($"Flat with id {id} removed");
        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}