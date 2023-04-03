using System.Text.Json;
using BLL;
using BLL.models;
using DAL;

namespace UnitTests
{
    class FileWriterMock : IWriter
    {
        public FileWriterMock(string filePath, string entityName)
        {
        }

        public void Write<T>(T data)
        {
            var json = JsonSerializer.Serialize(data);
            
            Assert.IsTrue(json.Contains("test"));
        }

        public void Remove<T>(string id)
        {
            throw new NotImplementedException();
        }

        public void Replace<T>(T data)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            Assert.IsTrue(id is string);
        }

        List<T> IWriter.ReadAll<T>()
        {
            return new List<T>();
        }
    }

    public class VisitRepositoryTest
    {
    private VisitRepository _visitRepository;
    private VisitRepository _visitRepositoryActual;
    
    [SetUp]
    public void Setup()
    {
        var fileWriterMock = new FileWriterMock("visits-test.txt", nameof(Visit));
        var fileWriter = new FileWriter("visits-test.txt", nameof(Visit));

        _visitRepository = new VisitRepository(fileWriterMock);
        _visitRepositoryActual = new VisitRepository(fileWriter);
    }

    [Test]
    public void TestWriteVisit()
    {
        _visitRepository.createVisit(
            DateTime.Now,
            "test"
        );
    }
    
    [Test]
    public void GetAllVisits()
    {
        var visits = _visitRepositoryActual.getAllVisits();
        
        Assert.IsTrue(visits.Count == 0);
    }
    
    [Test]
    public void GetVisit()
    {
        try
        {
            var visit = _visitRepositoryActual.getVisit("test");
        } 
        catch (VisitNotFoundException e)
        {
            Assert.IsTrue(e.Message == "Visit with id test not found");
        }
    }
}
}
