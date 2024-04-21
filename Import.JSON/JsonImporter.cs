using System.Diagnostics;
using Newtonsoft.Json;

namespace GV.Repositories.JSON;

internal class JsonImporter
{
    internal static bool TryImport<T>(string path, out T? newObject)
    {
        try
        {
            string jsonString = File.ReadAllText(path);
            T? @object = JsonConvert.DeserializeObject<T>(jsonString);

            newObject = @object;
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Object not deserializable!\n{e}");

            newObject = default;
            return false;
        }
    }
}
