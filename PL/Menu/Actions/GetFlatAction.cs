using BLL;

namespace kyrsova_1.Actions;

public class GetFlatAction : ConsoleActionAbstract
{
    public GetFlatAction(string name, int index) : base(name, index)
    {
    }
    
    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var id = consoleHelpers.GetStringWithMessage("Enter flat id:");

        try
        {
            var flat = flatRepository.GetFlat(id);
            consoleHelpers.PrintFormattedTableHeader(new string[]{"Id", "Price", "Address", "Description", "Rooms", "Area", "Owner"});
            consoleHelpers.PrintFormattedTableRow(flat);

        } catch (Exception e)
        {
            Console.WriteLine($"Flat with id {id} not found");
        }
    }
}