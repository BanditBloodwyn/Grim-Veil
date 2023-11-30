namespace Managers.SceneManagement;

public class SceneManager
{
    private static readonly Dictionary<string, Scene> _loadedScenes = new();

    public static bool TryGetSceneByName(string sceneName, out Scene scene)
    {
        scene = new Scene();

        if (_loadedScenes.TryGetValue(sceneName, out Scene? loadedScene))
        {
            scene = loadedScene;
            return true;
        }

        return false;
    }

    public static void AddScene(string sceneName, Scene scene)
    {
        _loadedScenes.TryAdd(sceneName, scene);
    }
}