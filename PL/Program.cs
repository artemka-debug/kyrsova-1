using BLL.models;
using BLL;
using DAL;

namespace kyrsova_1
{
    public class Program
    {
        public static void Main()
        {
            var flatWriter = new FileWriter("flatss.txt", nameof(Flat));
            var visitWriter = new FileWriter("visits.txt", nameof(Visit));
            
            var visitRepository = new VisitRepository(visitWriter);
            var flatRepository = new FlatRepository(flatWriter);
            var consoleHelpers = new ConsoleHelpers();
            
            var menu = new Menu(
                flatRepository,
                visitRepository,
                consoleHelpers
            );

            menu.MainMenu();
        }
    }
}
