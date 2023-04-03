using BLL;

namespace kyrsova_1.Actions;

public class BookVisitAction : ConsoleActionAbstract
{
    public BookVisitAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter flat id:");
        var date = consoleHelpers.GetDateWithMessage("Enter date of visit:");

        try
        {
            var flat = flatRepository.GetFlat(id);
            visitRepository.createVisit(date, id);
            Console.WriteLine($"Flat with id {id} booked on {date}");
        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}