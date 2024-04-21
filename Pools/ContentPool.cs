using GV.Globals.Enums;
using GV.Globals.World;
using Repositories.JSON;

namespace GV.Pools;

public static class ContentPool
{
    private static readonly JsonRepository _jsonRepository = new();

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
        TileType[] tileTypes = _jsonRepository.LoadAll<TileType>().ToArray();

        foreach (TileType tileType in tileTypes)
            TileTypes.Add(tileType.Name, tileType);
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