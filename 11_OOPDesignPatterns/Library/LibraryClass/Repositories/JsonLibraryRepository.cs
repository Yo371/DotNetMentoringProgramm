using Library.Models;
using Newtonsoft.Json;

namespace LibraryClass.Repositories
{
    public class JsonLibraryRepository : ILibraryRepository<LibraryItem>
    {
        private string _path;

        public JsonLibraryRepository(string path)
        {
            _path = path;
        }

        public List<LibraryItem>? GetAll()
        {
            List<LibraryItem> outputList;

            using Stream fileStream = new FileStream(_path, FileMode.Open);
            using StreamReader streamReader = new StreamReader(fileStream);
            using JsonReader jsonReader = new JsonTextReader(streamReader);

            JsonSerializer jsonSerializer = new JsonSerializer();

            jsonSerializer.TypeNameHandling = TypeNameHandling.Auto;
            outputList = jsonSerializer.Deserialize<List<LibraryItem>>(jsonReader);


            return outputList;
        }

        public void Update(List<LibraryItem> list)
        {
            var jsonSerializer = new JsonSerializer();

            if (File.Exists(_path)) File.Delete(_path);

            using StreamWriter streamWriter = new StreamWriter(_path);
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);

            jsonSerializer.TypeNameHandling = TypeNameHandling.Auto;

            jsonSerializer.Serialize(jsonWriter, list);
        }
    }
}