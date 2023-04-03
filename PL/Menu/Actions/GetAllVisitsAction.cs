using BLL;

namespace kyrsova_1.Actions;

public class GetAllVisitsAction : ConsoleActionAbstract
{
    public GetAllVisitsAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var visits = visitRepository.getAllVisits();
        
        consoleHelpers.PrintFormattedTableHeader(new string[]{"Id", "Flat Id", "Date"});
        foreach (var visit in visits)
        {
            Console.WriteLine(visit);
        }
    }
}