using BLL.models;
using DAL;

namespace BLL;

public class FlatNotFoundException : Exception
{
    public FlatNotFoundException(string message) : base(message)
    {
    }
}

public class FlatRepository
{
    private readonly IWriter _writer;
    
    public FlatRepository(IWriter writer)
    {
        _writer = writer;
    }
    
    public void createRentableFlat(
        double price,
        string address,
        string description,
        int rooms,
        double area
    )
    {
        var flat = new Flat(
            Guid.NewGuid().ToString("N").Substring(0, 5),
            new FlatPrice(price, PriceType.PerMonth),
            address,
            description,
            rooms,
            area,
            null
        );
        
        _writer.Write(flat);
    }
    
    public void createSellableFlat(
        double price,
        string address,
        string description,
        int rooms,
        double area
    )
    {
        var flat = new Flat(
            Guid.NewGuid().ToString("N").Substring(0, 5),
            new FlatPrice(price, PriceType.OneTime),
            address,
            description,
            rooms,
            area,
            null
        );
        
        _writer.Write(flat);
    }
    
    public void rentFlat(string flatId, string ownerId)
    {
        var flat = GetFlat(flatId);
        flat.ownerId = ownerId;
        
        _writer.Replace(flat);
    }
    
    public void buyFlat(string flatId, string ownerId)
    {
        var flat = GetFlat(flatId);
        flat.ownerId = ownerId;
        
        _writer.Replace(flat);
    }
    
    public void RemoveFlat(string id)
    {
        _writer.Remove<Flat>(id);
    }
    
    public Flat GetFlat(string id) 
    {
        var flats = _writer.ReadAll<Flat>();
        var flat = flats.Find(f =>
        {
            Console.WriteLine(f.id);
            return f.id == id;
        });

        if (flat == null)
        {
            throw new FlatNotFoundException($"Cannot find flat with id: {id}");
        }

        return flat;
    }
    
    public List<Flat> GetAllFlats()
    {
        return _writer.ReadAll<Flat>();
    }
}