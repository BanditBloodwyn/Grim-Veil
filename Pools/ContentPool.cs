using Globals.Enums;
using Globals.World;
using Repositories.JSON;

namespace Pools;

public static class ContentPool
{
    public static Dictionary<object, TileType> TileTypes = new();
    
    public static void LoadContentByStateName(SceneNames sceneName)
    {
        switch (sceneName)
        {
            case SceneNames.SplashScreen:
                LoadSplashScreenContent();
                break;
            case SceneNames.StartupLoadingScreen:
                LoadStartupLoadingScreenContent();
                break;
            case SceneNames.MainMenu:
                LoadMainMenuContent();
                break;
            case SceneNames.IngameLoadingScreen:
                LoadIngameLoadingScreenContent();
                break;
            case SceneNames.Ingame_Normal:
                LoadMainGameContent();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
        }
    }

    private static void LoadSplashScreenContent()
    {
    }

    private static void LoadStartupLoadingScreenContent()
    {
        JsonRepository repo = new JsonRepository();
        TileType[] tileTypes = repo.LoadAll<TileType>().ToArray();
    }

    private static void LoadMainMenuContent()
    {
    }

    private static void LoadIngameLoadingScreenContent()
    {
    }

    private static void LoadMainGameContent()
    {
    }
}