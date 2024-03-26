using System.Reflection;

namespace Repositories.JSON;

public class JsonRepository
{
    private readonly string _jsonSavePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Json";

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
        foreach (string filePath in Directory.GetFiles($"{_jsonSavePath}\\{typeof(T).Name}", "*.json"))
        {
            if (JsonImporter.TryImport(filePath, out T? instance))
                yield return instance!;
        }
    }

    public void Delete<T>(T objectToDelete)
    {

    }

}