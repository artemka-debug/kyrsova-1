using BLL.models;
using BLL;
using DAL;

namespace lab_yana_5
{
    public class Program
    {
        public static void Main()
        {
            var fileWriter = new FileWriter("students.txt", nameof(Student));
            var studentService = new StudentService(fileWriter);
            var consoleHelpers = new ConsoleHelpers();
            
            var menu = new Menu(
                studentService,
                consoleHelpers
            );

            menu.MainMenu();
        }
    }
}
