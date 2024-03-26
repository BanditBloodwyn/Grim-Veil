using System.Diagnostics;
using Newtonsoft.Json;

namespace Repositories.JSON;

internal class JsonImporter
{
    internal static bool TryImport<T>(string path, out T? newObject)
    {
        T? @object = JsonConvert.DeserializeObject<T>(path);
        
        if(@object == null)
        {
            Debug.WriteLine("Object not deserializable!");
            newObject = default;
            return false;
        }

        newObject = @object;
        return true;
    }
}
