using Globals.Enums;

namespace Managers.SceneManagement;

public class SceneManager
{
    private static readonly Dictionary<StateNames, Scene> _loadedScenes = new();

    public static bool TryGetSceneByName(StateNames stateName, out Scene? scene)
    {
        scene = null;

        if (_loadedScenes.TryGetValue(stateName, out Scene? loadedScene))
        {
            scene = loadedScene;
            return true;
        }

        if (SceneBuilder.TryBuildByStateName(stateName, out Scene? newScene))
        {
            AddScene(stateName, newScene!);
            scene = newScene!;
            return true;
        }

        return false;
    }

    private static void AddScene(StateNames stateName, Scene scene)
    {
        _loadedScenes.TryAdd(stateName, scene);
    }
}