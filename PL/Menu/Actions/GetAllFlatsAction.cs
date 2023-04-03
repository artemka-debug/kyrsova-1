using BLL;

namespace kyrsova_1.Actions;

public class GetAllFlatsAction : ConsoleActionAbstract
{
    public GetAllFlatsAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var flats = flatRepository.GetAllFlats();
        consoleHelpers.PrintFormattedTableHeader(new string[]{"Id", "Price", "Address", "Description", "Rooms", "Area", "Owner"});
        foreach (var flat in flats)
        {
            consoleHelpers.PrintFormattedTableRow(flat);
        }
    }
}