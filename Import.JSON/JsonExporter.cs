using Newtonsoft.Json;

namespace Repositories.JSON;

internal class JsonExporter
{
    internal static void Export<T>(string path, T objectToSave)
    {
        JsonSerializer serializer = new();

        using StreamWriter sw = new(path);
        using JsonWriter writer = new JsonTextWriter(sw);
        
        serializer.Serialize(writer, objectToSave);
    }
}