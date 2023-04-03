namespace BLL.models;

public class Visit
{
    public string id { get; private set; }
    public DateTime date { get; private set; }
    public string flatId { get; private set; }
    
    public Visit(string id, DateTime date, string flatId)
    {
        this.id = id;
        this.date = date;
        this.flatId = flatId;
    }
}