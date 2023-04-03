using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DAL
{
    public class FileWriter : IWriter
    {
        private readonly string _filePath;
        private readonly string _entityName;

        public FileWriter(string filePath, string entityName)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            _entityName = entityName;
        }

        public List<T> ReadAll<T>()
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }

            using FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            var buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            var json = Encoding.ASCII.GetString(buffer);
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                 JsonNumberHandling.WriteAsString
            };
            

            var entities = JsonSerializer.Deserialize<T[]>(json, options);
            
            if (entities == null)
            {
                return new List<T>();
            }

            return entities.ToList();
        }

        public void Write<T>(T data)
        {
            var existingEntities = ReadAll<T>();
            existingEntities.Add(data);

            var json = ToJson(existingEntities);

            using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
            fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
        }

        public void Remove<T>(string id)
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            
            var existingEntities = ReadAll<T>().Where(entity => ((BaseEntity)entity).id != id).ToList();
            
            var json = ToJson(existingEntities);
            
            using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
            fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
        }
        
        public void Replace<T>(T data)
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            
            var existingEntities = ReadAll<T>().Where(entity =>  ((BaseEntity)entity).id != ((BaseEntity)data).id).ToList();
            existingEntities.Add(data);
            
            var json = ToJson(existingEntities);
            
            using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
            fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
        }
        
        private string ToJson<T>(T data)
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                 JsonNumberHandling.WriteAsString
            };
            
            return JsonSerializer.Serialize(data, options);
        }
    }
}