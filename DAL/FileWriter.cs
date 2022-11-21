using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DAL
{
    public class FileWriter : IFileWriter
    {
        private readonly string _filePath;
        private readonly string _entityName;

        public FileWriter(string filePath, string entityName)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            _entityName = entityName;
        }

        public T[] ReadAll<T>()
        {
            if (!File.Exists(_filePath))
            {
                return Array.Empty<T>();
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

            T[] result = new T[100];
            var current = 0;

            foreach (var line in json.Split("\n"))
            {
                if (line.StartsWith(_entityName) || line.Trim() == "")
                {
                    continue;
                }

                result[current++] = JsonSerializer.Deserialize<T>(line, options);
            }

            return result.Take(current).ToArray();
        }

        public void Write(string data)
        {
            using FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
            fs.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
        }

        public void Remove(string firstName, string lastName)
        {
            if (!File.Exists(_filePath))
            {
                return;
            }

            using FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            var buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            var json = Encoding.ASCII.GetString(buffer);
            var lines = json.Split("\n");
            var removeIndex = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (line.Contains($"\"FirstName\":\"{firstName}\",\"SecondName\":\"{lastName}\""))
                {
                    removeIndex = i;
                }
            }

            lines = lines.Where((_, index) => index != removeIndex - 1 && index != removeIndex).ToArray();
            json = string.Join("\n", lines);

            using StreamWriter writer = new StreamWriter(_filePath, false);
            writer.Write(json);
        }
    }
}