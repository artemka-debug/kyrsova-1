using static System.Guid;

namespace BLL.models;

public enum PriceType
{
    PerMonth,
    OneTime
}

public class FlatPrice
{
    public double price { get; private set; }
    public PriceType type { get; private set; }
    
    public FlatPrice(double price, PriceType type)
    {
        this.price = price;
        this.type = type;
    }
    
    public override string ToString()
    {
        var text = type == PriceType.PerMonth ? "per month" : "one time";
        
        return $"{price}$ {text}";
    }
}

public class Flat
{
    public string id { get; private set; }
    public FlatPrice price { get; private set; }
    public string address { get; private set; }
    public string description { get; private set; }
    public int rooms { get; private set; }
    public double area { get; private set; }
    public string? ownerId { get; set; }
    
    public Flat(string id, FlatPrice price, string address, string description, int rooms, double area, string? ownerId)
    {
        this.id = id;
        this.price = price;
        this.address = address;
        this.description = description;
        this.rooms = rooms;
        this.area = area;
        this.ownerId = ownerId;
    }
}