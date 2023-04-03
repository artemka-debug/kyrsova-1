using BLL;

namespace kyrsova_1.Actions;

public class AddFlatForRentAction : ConsoleActionAbstract
{
    public AddFlatForRentAction(string name, int index) : base(name, index)
    {
    }

    public override void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository)
    {
        var address = consoleHelpers.GetStringWithMessage("Enter address:");
        var description = consoleHelpers.GetStringWithMessage("Enter description:");
        var rooms = consoleHelpers.GetIntegerWithMessage("Enter number of rooms:");
        var area = consoleHelpers.GetNumberWithMessage("Enter area:");
        var price = consoleHelpers.GetNumberWithMessage("Enter price:");
        
        flatRepository.createRentableFlat(
            price,
            address,
            description,
            rooms,
            area
        );
    }  
}