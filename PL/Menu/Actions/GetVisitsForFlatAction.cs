using BLL;

namespace kyrsova_1.Actions;

public class GetVisitsForFlatAction : ConsoleActionAbstract
{
    public GetVisitsForFlatAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter flat id:");

        try
        {
            var flat = flatRepository.GetFlat(id);
            var visits = visitRepository.getAllVisits();

            var flatVisits = visits.FindAll(visit => visit.flatId == id);
            
            consoleHelpers.PrintFormattedTableHeader(new string[]{"Id", "Flat Id", "Date"});
            foreach (var visit in flatVisits)
            {
                consoleHelpers.PrintFormattedTableRow(visit);
            }
        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}