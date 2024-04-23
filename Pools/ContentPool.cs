using GV.Repositories.JSON;
using GV.WorldManagement.Data;

namespace GV.Pools;

public static class ContentPool
{
    private static readonly JsonRepository _jsonRepository = new();

    public static Dictionary<object, TileType> TileTypes = [];

    public static void LoadContentByStateName(string sceneName)
    {
        switch (sceneName)
        {
            case "SplashScreen":
                LoadSplashScreenContent();
                break;
            case "StartupLoadingScreen":
                LoadStartupLoadingScreenContent();
                break;
            case "MainMenu":
                LoadMainMenuContent();
                break;
            case "IngameLoadingScreen":
                LoadIngameLoadingScreenContent();
                break;
            case "Ingame":
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