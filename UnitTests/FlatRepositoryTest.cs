using System.Text.Json;
using BLL;
using BLL.models;
using DAL;

namespace UnitTests
{
    class WriterMock : IWriter
    {
        public WriterMock(string filePath, string entityName)
        {
        }

        public void Write<T>(T data)
        {
            var json = JsonSerializer.Serialize(data);
            
            Assert.IsTrue(json.Contains("test"));
        }

        public void Remove<T>(string id)
        {
        }

        public void Replace<T>(T data)
        {
            throw new NotImplementedException();
        }

        List<T> IWriter.ReadAll<T>()
        {
            return new List<T>();
        }
    }

    public class FlatRepositoryTest
    {
    private FlatRepository _flatRepository;
    
    [SetUp]
    public void Setup()
    {
        var fileWriterMock = new WriterMock("flat-test.txt", nameof(Visit));

        _flatRepository = new FlatRepository(fileWriterMock);
    }

    [Test]
    public void TestWriteVisit()
    {
        _flatRepository.createRentableFlat(
            1.1,
            "test",
            "test",
            1,
            1.1
        );
    }
    
    [Test]
    public void TestRemoveVisit()
    {
        try
        {
            _flatRepository.RemoveFlat("test");
        } catch (FlatNotFoundException e)
        {
            Assert.IsTrue(e.Message == "Flat with id test not found");
        }
    }
    
    [Test]
    public void TestGetAllFlats()
    {
        var flats = _flatRepository.GetAllFlats();
        
        Assert.IsTrue(flats.Count == 0);
    }
    
    [Test]
    public void TestGetFlatById()
    {
        try
        {
            _flatRepository.GetFlat("test");
        } catch (FlatNotFoundException e)
        {
            Assert.IsTrue(e.Message == "Cannot find flat with id: test");
        }
    }
}
}
