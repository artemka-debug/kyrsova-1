namespace DAL;

public interface IFileWriter
{
    T[] ReadAll<T>();
    void Write(string data);
    void Remove(string firstName, string lastName);
}