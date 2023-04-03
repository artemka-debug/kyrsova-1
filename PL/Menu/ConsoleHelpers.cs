using BLL.models;

namespace kyrsova_1
{
    public class ConsoleHelpers
{
    private int tableWidth = 100;
    
    public double GetValidNumberFromConsole(string message, double[] validNumbers)
    {
        double number = 0;
        bool isValid = false;
        
        do {
            string input = Console.ReadLine();
            isValid = double.TryParse(input, out number) && (validNumbers.Length == 0 || validNumbers.Contains(number));
            if (isValid)
            {
                return number;
            }
            Console.WriteLine(message);
        } while (!isValid);

        return number;
    }
    
    public string GetStringWithMessage(string message)
    {
        Console.WriteLine(message);
        var result = Console.ReadLine();
        
        return result ?? string.Empty;
    }
    
    public DateTime GetDateWithMessage(string message)
    {
        DateTime date = DateTime.MinValue;
        bool isValid = false;
        
        do {
            string input = Console.ReadLine();
            isValid = DateTime.TryParse(input, out date);
            if (isValid)
            {
                return date;
            }
            Console.WriteLine(message);
        } while (!isValid);

        return date;
    }
    
    public double GetNumberWithMessage(string message)
    {
        Console.WriteLine(message);
        return GetValidNumberFromConsole("Invalid number", Array.Empty<double>());
    }
    
    public int GetIntegerWithMessage(string message)
    {
        Console.WriteLine(message);
        var result = 0.1;

        do
        {
            result = GetValidNumberFromConsole("Invalid number", Array.Empty<double>());
        } while (result % 1 != 0);

        return (int)result;
    }

    public void PrintFormattedTableRow(Visit visit)
    {
        PrintRow(
            visit.id,
            visit.flatId,
            visit.date.ToString("dd.MM.yyyy")
        );
    }
    
    public void PrintFormattedTableRow(Flat flat)
    {
        var priceType = flat.price.type == PriceType.OneTime ? "For sale" : "For rent";
        
        PrintRow(
            flat.id,
            flat.address,
            flat.area.ToString(),
            flat.rooms.ToString(),
            flat.price.ToString(),
            flat.ownerId ?? priceType,
            flat.description
        );
    }
    
    public void PrintFormattedTableHeader(string[] headers)
    {
        PrintRow(headers);
    }
    
    public void PrintLine()
    {
        Console.WriteLine(new string('-', tableWidth));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (tableWidth - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }

        return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}
}
