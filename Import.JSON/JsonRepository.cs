using System.Reflection;

namespace GV.Repositories.JSON;

public class JsonRepository
{
    private readonly string _jsonSavePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\Json";

    public JsonRepository()
    {
        if(!Directory.Exists(_jsonSavePath))
            Directory.CreateDirectory(_jsonSavePath);
    }

    public void Save<T>(T objectToSave)
    {
        JsonExporter.Export(_jsonSavePath, objectToSave);
    }

    public IEnumerable<T> LoadAll<T>()
    {
        string path = $"{_jsonSavePath}\\{typeof(T).Name}";

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        foreach (string filePath in Directory.GetFiles(path, "*.json"))
        {
            if (JsonImporter.TryImport(filePath, out T? instance))
                yield return instance!;
        }
    }

    public void Delete<T>(T objectToDelete)
    {

    }

}