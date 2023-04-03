namespace DAL;

public interface BaseEntity
{
    string id { get; }
}

public interface IWriter
{
    List<T> ReadAll<T>();
    void Write<T>(T data);
    void Remove<T>(string id);
    
    void Replace<T>(T data);
}