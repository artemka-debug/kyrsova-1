using BLL;

namespace kyrsova_1.Actions;

public class RemoveBookedVisitAction : ConsoleActionAbstract
{
    public RemoveBookedVisitAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter visit id:");

        try
        {
            visitRepository.getVisit(id);
            visitRepository.removeVisit(id);
            Console.WriteLine($"Visit with id {id} removed");
        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}