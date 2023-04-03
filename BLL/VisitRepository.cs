using BLL.models;
using DAL;

namespace BLL;

public class VisitNotFoundException : Exception
{
    public VisitNotFoundException(string message) : base(message)
    {
    }
}

public class VisitRepository
{
    private readonly IWriter _writer;
    
    public VisitRepository(IWriter writer)
    {
        _writer = writer;
    }
    
    public void createVisit(DateTime date, string flatId)
    {
        var visit = new Visit(
            Guid.NewGuid().ToString("N").Substring(0, 5), 
            date, 
            flatId
        );
        
        _writer.Write(visit);
    }
    
    public void removeVisit(string id)
    {
        _writer.Remove<Visit>(id);
    }
    
    public List<Visit> getAllVisits()
    {
        return _writer.ReadAll<Visit>();
    }

    public Visit getVisit(string id)
    {
        var visits = _writer.ReadAll<Visit>();
        var visit = visits.Find(v => v.id == id);
        
        if (visit == null)
        {
            throw new VisitNotFoundException($"Visit with id {id} not found");
        }
        
        return visit;
    }
}