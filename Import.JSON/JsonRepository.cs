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
        string path = Path.Combine(_jsonSavePath, typeof(T).Name);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            return [];
        }
        
        return Directory.EnumerateFiles(path, "*.json")
            .Select(static filePath => JsonImporter.TryImport(filePath, out T? instance) ? instance : default)
            .Where(static instance => instance != null)!;
    }

    public void Delete<T>(T objectToDelete)
    {

    }

}