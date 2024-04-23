using GV.SceneManagement.Data;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GV.Pools;

public static class ResourcePool
{
    private static ContentManager? _contentManager;

    public static Dictionary<object, Texture2D> Textures = [];
    public static Dictionary<object, SpriteFont> Fonts = [];

    public static void Initialize(ContentManager content)
    {
        _contentManager = content;
    }

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
        if (_contentManager == null) 
            return;

        Textures.TryAdd("splashscreen", _contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.TryAdd("gameLogo", _contentManager.Load<Texture2D>("Images/logo"));

        Fonts.TryAdd("Default", _contentManager.Load<SpriteFont>("Fonts/Default"));
    }

    private static void LoadStartupLoadingScreenContent()
    {
        if (_contentManager == null)
            return;

        Textures.TryAdd("loadingScreen_Background1", _contentManager.Load<Texture2D>("Images/loadingScreen1"));
        Fonts.TryAdd("Default", _contentManager.Load<SpriteFont>("Fonts/Default"));
    }

    private static void LoadMainMenuContent()
    {
        if (_contentManager == null)
            return;

        Textures.TryAdd("mainMenu_Background", _contentManager.Load<Texture2D>("Images/title"));
    }

    private static void LoadIngameLoadingScreenContent()
    {
        if (_contentManager == null)
            return;
    }

    private static void LoadMainGameContent()
    {
        if (_contentManager == null)
            return;

        Textures.TryAdd("tile_grass", _contentManager.Load<Texture2D>("Environment/Tiles/grassTile"));
        Textures.TryAdd("tile_stone", _contentManager.Load<Texture2D>("Environment/Tiles/stoneTile"));
        Textures.TryAdd("tile_dirt", _contentManager.Load<Texture2D>("Environment/Tiles/dirtTile"));
        Textures.TryAdd("tile_water", _contentManager.Load<Texture2D>("Environment/Tiles/waterTile"));
    }
}