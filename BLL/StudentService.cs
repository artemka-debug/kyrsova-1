using System.Text.Json;
using BLL.models;
using DAL;

namespace BLL
{
    
public class StudentService 
{
    private readonly IFileWriter _fileWriter;
    
    public StudentService(IFileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public Student[] ReadStudentsWithIdealWeight()
    {
        var students = _fileWriter.ReadAll<Student>();
        return students.Where(IsStudentIdeal).ToArray();
    }
    
    public Student[] ReadAll()
    {
        return _fileWriter.ReadAll<Student>();
    }

    public void Write(Student data)
    {
        var json = $"{JsonSerializer.Serialize(data)}\n";
        var metadata = $"{data.GetType().Name} {data.FirstName}{data.SecondName}\n";
        var writeData = $"{metadata}{json}";
        
        _fileWriter.Write(writeData);
    }

    public void Remove(string firstName, string lastName)
    {
        _fileWriter.Remove(firstName, lastName);
    }

    public bool Exists(string firstName, string lastName)
    {
        var students = ReadAll();
        return students.Any(student => student.FirstName == firstName && student.SecondName == lastName);
    }

    public bool ChangeStudentWeightAndHeight(string firstName, string lastName, double weight, double height)
    {
        var students = ReadAll();
        var student = students.First(s => s.FirstName == firstName && s.SecondName == lastName);
        student.Weight = weight;
        student.Height = height;
        
        Remove(firstName, lastName);
        Write(student);
        return IsStudentIdeal(student);
    }
    
    public bool IsStudentIdeal(Student student)
    {
        return student.Height - 110 == student.Weight;
    }
}
}
