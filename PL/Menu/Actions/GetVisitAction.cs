using BLL;

namespace kyrsova_1.Actions;

public class GetVisitAction : ConsoleActionAbstract
{
    public GetVisitAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter visit id:");

        try
        {
            var visit = visitRepository.getVisit(id);
            
            consoleHelpers.PrintFormattedTableHeader(new string[]{"Id", "Flat Id", "Date"});
            consoleHelpers.PrintFormattedTableRow(visit);
        } catch (Exception e)
        {
            Console.WriteLine($"Visit with id {id} not found");
        }
    }
}