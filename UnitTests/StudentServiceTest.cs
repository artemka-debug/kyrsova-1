using BLL;
using BLL.models;
using DAL;

namespace UnitTests
{
    class FileWriterMock : IFileWriter
    {
        public FileWriterMock(string filePath, string entityName)
        {
        }

        public void Write(string data)
        {
            Console.WriteLine(data);
            var expectedString = "Student testtest\n{\"FirstName\":\"test\",\"SecondName\":\"test\",\"Height\":1,\"Weight\":2,\"StudentId\":\"test\",\"PassportSeries\":\"test\",\"PassportNumber\":\"test\"}\n";
            Assert.AreEqual(data, expectedString);
        }
        
        public T[] ReadAll<T>()
        {
            return new T[0];
        }

        public void Remove(string firstName, string lastName)
        {
            Assert.AreEqual(firstName, "test");
            Assert.AreEqual(lastName, "test");
        }
    }

    public class StudentServiceTest
{
    private StudentService _studentService;
    private StudentService _studentServiceActual;
    
    [SetUp]
    public void Setup()
    {
        var fileWriterMock = new FileWriterMock("students.txt", nameof(Student));
        var fileWriter = new FileWriter("students.txt", nameof(Student));

        _studentService = new StudentService(fileWriterMock);
        _studentServiceActual = new StudentService(fileWriter);
    }

    [Test]
    public void TestWriteStudent()
    {
        _studentService.Write(
            new Student(
                "test",
                "test",
                1,
                2,
                "test",
                "test","test")
            );
    }
    
    [Test]
    public void TestReadingEmptyStudents()
    {
        var students = _studentService.ReadAll();
        Assert.AreEqual(students.Length, 0);
    }

    [Test]
    public void TestRemoveStudent()
    {
        _studentServiceActual.Remove("test", "test");
    }
    
    [Test]
    public void TestReadStudentsWithIdealWeight()
    {
        var students = _studentService.ReadStudentsWithIdealWeight();
        Assert.AreEqual(students.Length, 0);
    }
    
    [Test]
    public void TestStudentExists()
    {
        _studentServiceActual.Write(
            new Student(
                "test",
                "test",
                1,
                2,
                "test",
                "test","test")
        );
        var exists = _studentServiceActual.Exists("test", "test");
        Assert.AreEqual(exists, true);
    }
    
    [Test]
    public void TestChangeStudentWeightAndHeight()
    {
        var exists = _studentServiceActual.ChangeStudentWeightAndHeight("test", "test", 1, 2);
        Assert.AreEqual(exists, false);
    }
    
    [Test]
    public void TestIsIdealStudentWeight()
    {
        var student = new Student(
            "test",
            "test",
            1,
            2,
            "test",
            "test", "test"); 
        var isStudentIdeal = _studentService.IsStudentIdeal(student);
        Assert.AreEqual(isStudentIdeal, false);
    }
}
}
