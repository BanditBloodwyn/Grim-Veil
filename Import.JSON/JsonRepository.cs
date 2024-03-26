namespace Repositories.JSON;

public class JsonRepository
{
    private const string JSONSAVEPATH = "";

    public void Save<T>(T objectToSave)
    {
        JsonExporter.Export(JSONSAVEPATH, objectToSave);
    }

    public IEnumerable<T> LoadAll<T>()
    {
        foreach (string filePath in Directory.GetFiles($"{JSONSAVEPATH}\\{typeof(T).Name}", "*.json"))
        {
            if (JsonImporter.TryImport(filePath, out T? instance))
                yield return instance!;
        }
    }

    public void Delete<T>(T objectToDelete)
    {

    }

}