using Globals.Enums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pools;

public static class ResourcePool
{
    public static Dictionary<object, Texture2D> Textures = new();
    public static Dictionary<object, SpriteFont> Fonts = new();

    public static void LoadContentByStateName(SceneNames sceneName, ContentManager contentManager)
    {
        switch (sceneName)
        {
            case SceneNames.SplashScreen:
                LoadSplashScreenContent(contentManager);
                break;
            case SceneNames.StartupLoadingScreen:
                LoadStartupLoadingScreenContent(contentManager);
                break;
            case SceneNames.MainMenu:
                LoadMainMenuContent(contentManager);
                break;
            case SceneNames.IngameLoadingScreen:
                LoadIngameLoadingScreenContent(contentManager);
                break;
            case SceneNames.Ingame_Normal:
                LoadMainGameContent(contentManager);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sceneName), sceneName, null);
        }
    }

    private static void LoadSplashScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("splashscreen", contentManager.Load<Texture2D>("Images/splashscreen"));
        Textures.TryAdd("gameLogo", contentManager.Load<Texture2D>("Images/logo"));

        Fonts.TryAdd("Default", contentManager.Load<SpriteFont>("Fonts/Default"));
    }

    private static void LoadStartupLoadingScreenContent(ContentManager contentManager)
    {
        Textures.TryAdd("loadingScreen_Background1", contentManager.Load<Texture2D>("Images/loadingScreen1"));
        Fonts.TryAdd("Victorian", contentManager.Load<SpriteFont>("Fonts/VictorianText"));
    }

    private static void LoadMainMenuContent(ContentManager contentManager)
    {
        Textures.TryAdd("mainMenu_Background", contentManager.Load<Texture2D>("Images/title"));
    }

    private static void LoadIngameLoadingScreenContent(ContentManager contentManager)
    {
    }

    private static void LoadMainGameContent(ContentManager contentManager)
    {
        Textures.TryAdd("tile_grass", contentManager.Load<Texture2D>("Environment/Tiles/grassTile"));
        Textures.TryAdd("tile_stone", contentManager.Load<Texture2D>("Environment/Tiles/stoneTile"));
        Textures.TryAdd("tile_dirt", contentManager.Load<Texture2D>("Environment/Tiles/dirtTile"));
        Textures.TryAdd("tile_water", contentManager.Load<Texture2D>("Environment/Tiles/waterTile"));
    }
}